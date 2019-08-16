using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoBitacorasCientificas.Models;
using PayPal.Api;
using ProyectoBitacorasCientificas.App_Start;

namespace ProyectoBitacorasCientificas.Controllers
{
    public class ConsultaController : Controller
    {

        private ApplicationDbContext _context;

        public ConsultaController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Consulta
        public ActionResult Index()
        {
            return View();
        }

        #region BitacoraRegistro

        public ActionResult BitacorasRegistroCrear(
            string descripcion, string entidadRelacionada
        )
        {
            var bitacoraRegistro = new BitacoraRegistro
            {
                descripcion = descripcion,
                entidadRelacionada = entidadRelacionada
            };
            _context.BitacoraRegistros.Add(bitacoraRegistro);
            _context.SaveChanges();
            return new EmptyResult();
        }

        // GET: Consulta/Bitacora
        public ActionResult Bitacoras()
        {
            if (User.IsInRole(RoleName.CanManageAdministration) || User.IsInRole(RoleName.CanManageConsulting))
            {
                var bitacorasRegistro = _context.BitacoraRegistros.ToList();
                return View(bitacorasRegistro);
            }
            else
            {
                return View("RestrictedAccess");
            }
        }

        public ActionResult CompraBitacoras()
        {
            var listaBitacoras = _context.Bitacoras.ToList();
            return View(listaBitacoras);
        }


        #endregion

        // GET: Consulta/Errores
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsulting)]
        public ActionResult Errores()
        {
            if (User.IsInRole(RoleName.CanManageAdministration) || User.IsInRole(RoleName.CanManageConsulting))
            {
                var errores = _context.Errors.ToList();
                return View(errores);
            }
            else
            {
                return View("RestrictedAccess");
            }
        }

        // GET: Consulta/Descargas
        [Authorize(Roles = RoleName.CanManageAdministration + "," + RoleName.CanManageConsulting)]
        public ActionResult Descargas()
        {
            return View();
        }

        #region Pago Paypal

        private PayPal.Api.Payment payment;

        /// <summary>
        /// Accion para iniciar un pago con paypal
        /// </summary>
        /// <param name="Cancel"></param>
        /// <returns>Resultado del Pago</returns>
        public ActionResult PaymentWithPaypal(int id, string Cancel = null)
        {
            
            //getting the apiContext  
            APIContext apiContext = PayPalConfig.GetAPIContext();
            try
            {
                if (!string.IsNullOrEmpty(Cancel))
                {
                    if (Cancel.ToUpper().Equals("TRUE"))
                    {
                        return View("CancelView");
                    }
                }

                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + string.Format("/Consulta/PaymentWithPayPal/{0}?", id.ToString());
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(id, apiContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("FailureView");
            }

            

            //on successful payment, show success page to user.  
            return View("SuccessView");
        }


        /// <summary>
        /// Enviar pago a paypal
        /// </summary>
        /// <param name="apiContext"></param>
        /// <param name="payerId"></param>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
               
            };
            this.payment = new Payment()
            {
                id = paymentId
            
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        /// <summary>
        /// Crear pago para enviar a paypal, aqui es donde se consulta el producto
        /// </summary>
        /// <param name="apiContext">Contexto de PayPal de ambiente (sanbox o produccion) y llaves de api y privada</param>
        /// <param name="redirectUrl">URL donde se dirije cuando termina la transaccion (exitosa o cancelada, rechazada)</param>
        /// <returns>Pago construido con datos desde la DB</returns>
        private Payment CreatePayment(int productId, APIContext apiContext, string redirectUrl)
        {
            Bitacora bitacorComprada = (from bitItem in _context.Bitacoras
                                       where bitItem.id == productId
                                       select bitItem).FirstOrDefault();

            
            Factura nuevaFactura = new Factura {
                BitacoraId = bitacorComprada.id,
                monto = double.Parse(bitacorComprada.precio),
                fechaEmision = DateTime.Now
            };

            _context.Facturas.Add(nuevaFactura);

            _context.SaveChanges();

            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = bitacorComprada.nombreExperimento,
                currency = "USD",
                price = nuevaFactura.monto.ToString(), 
                quantity = "1",
                sku = bitacorComprada.id.ToString()
            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = nuevaFactura.monto.ToString()
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = nuevaFactura.monto.ToString(), // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = String.Format("Proyecto Bitacora, compra de bitacora {0}", bitacorComprada.nombreExperimento),
                invoice_number = nuevaFactura.id.ToString(), //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }

        #endregion
    }
}