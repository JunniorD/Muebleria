using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
   public class datProducto
    {
        #region singleton
        private static readonly datProducto _instancia = new datProducto();
        public static datProducto Instancia
        {
            get { return datProducto._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<Producto> ListarProducto()
        {
            SqlCommand cmd = null;
            List<Producto> lista = new List<Producto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("listarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto bo = new Producto();
                    bo.Codigo = Convert.ToInt16(dr["Codigo"]);
                    bo.Nombre = dr["Nombre"].ToString();
                    bo.Calidad = dr["Calidad"].ToString();
                    bo.Estado = Convert.ToBoolean(dr["Estado"]);
                    lista.Add(bo);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }


        public Boolean InsertarProducto(Producto bol)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", bol.Nombre);
                cmd.Parameters.AddWithValue("@Calidad", bol.Calidad);
                cmd.Parameters.AddWithValue("@Estado", bol.Estado);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                { inserta = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }


        public Producto BuscarProducto(int codigo)
        {
            SqlCommand cmd = null;
            Producto bol = new Producto();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    bol.Codigo = Convert.ToInt16(dr["Codigo"]);
                    bol.Nombre = dr["Nombre"].ToString();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return bol;
        }

        public Boolean InhabilitarProducto(Producto bol)
        {
            SqlCommand cmd = null;
            Boolean Inhabilitar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("eliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", bol.Codigo);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { Inhabilitar = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return Inhabilitar;
        }



        #endregion metodos
    }
}
