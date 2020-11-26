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
    public class LogModelo
    {
        #region singleton
        private static readonly LogModelo _instancia = new LogModelo();
        public static LogModelo Instancia
        {
            get { return LogModelo._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<Modelos> ListarModelo()
        {
            try
            {
                return datModelo.Instancia.ListarModelo();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void InsetarModelo(Modelos mo)
        {
            try
            {
                datModelo.Instancia.InsertarModelo(mo);
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion metodos

    }
}
