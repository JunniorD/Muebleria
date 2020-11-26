using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using AccesoDatos;

namespace Logica
{
   public class LogoColor
    {
        #region singleton
        private static readonly LogoColor _instancia = new LogoColor();
        public static LogoColor Instancia
        {
            get { return LogoColor._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<Colores> ListaColor()
        {
            try
            {
                return datColor.Instancia.ListarColor();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void InsetarColor(Colores pro)
        {
            try
            {
                datColor.Instancia.InsertarColor(pro);
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion metodos


    }
}
