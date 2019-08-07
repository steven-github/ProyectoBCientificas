using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBitacorasCientificas.Models
{
    public static class BitacoraRegistroEnum
    {
        #region CRUD
        public const string create = "Creado"; 
        public const string edit = "Editado";
        public const string delete = "Eliminado";

        public static string stringEditDelete(string entity, int id, string action)
        {
            return entity + " id:" + id + " " + action;
        }

        #endregion

        #region AdminController 
        public const string ramasCientificas = "Rama Cientifica ";
        public const string proyectos = "Proyecto ";
        public const string bitacorasCientificas = "Bitacora Cientifica ";
        public const string objetivos = "Objetivo ";
        #endregion

        #region SeguridadController 
        public const string rolLaboratorio = "Rol Laboratorio";
        #endregion
    }
}