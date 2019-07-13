using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;

namespace testApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string credential_path = @"\\Mac\Home\Documents\Servicios Web\Project\ProyectoBCientificas\GoogleCloud\ProyectoBCientificas-b136277ba268.json";
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            TranslationClient client = TranslationClient.Create();
            var response = client.TranslateText("Hello World.", "ru");
              try
            {
                //...
            }
            finally
            {
                Console.WriteLine(response.TranslatedText);
                Console.ReadLine();
            }
            
            // $env:GOOGLE_APPLICATION_CREDENTIALS = " \\Mac\Home\Documents\Servicios Web\Project\ProyectoBCientificas\GoogleCloud\ProyectoBCientificas-b136277ba268.json"
        }
    }
}
