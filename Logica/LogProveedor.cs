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
    public class LogProveedor
    {
        #region singleton
        private static readonly LogProveedor _instancia = new LogProveedor();
        public static LogProveedor Instancia
        {
            get { return LogProveedor._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<Proveedores> ListarProveedor()
        {
            try
            {
                return datProveedor.Instancia.ListarProveedor();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void InsetarProveedor(Proveedores pro)
        {
            try
            {
                datProveedor.Instancia.InsertarProveedor(pro);
            }
            catch (Exception e)
            { throw e; }
        }

        public Proveedores BuscarProveedor(int codigo)
        {
            try
            {
                return datProveedor.Instancia.BuscarProveedor(codigo);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InhabilitarProveedor(Proveedores bol)
        {
            try
            {
                return datProveedor.Instancia.InhabilitarProveedor(bol);
            }
            catch (Exception e) { throw e; }
        }



        #endregion metodos
    }
}
