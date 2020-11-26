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
    public class LogProducto
    {
        #region singleton
        private static readonly LogProducto _instancia = new LogProducto();
        public static LogProducto Instancia
        {
            get { return LogProducto._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<Producto> ListarProducto()
        {
            try
            {
                return datProducto.Instancia.ListarProducto();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void InsetarProducto(Producto pro)
        {
            try
            {
                datProducto.Instancia.InsertarProducto(pro);
            }
            catch (Exception e)
            { throw e; }
        }

        public Producto BuscarProducto(int codigo)
        {
            try
            {
                return datProducto.Instancia.BuscarProducto(codigo);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InhabilitarProducto(Producto bol)
        {
            try
            {
                return datProducto.Instancia.InhabilitarProducto(bol);
            }
            catch (Exception e) { throw e; }
        }



        #endregion metodos

    }
}
