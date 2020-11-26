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
   public class datProveedor
    {
        #region singleton
        private static readonly datProveedor _instancia = new datProveedor();
        public static datProveedor Instancia
        {
            get { return datProveedor._instancia; }
        }
        #endregion singleton
        #region metodos

        public List<Proveedores> ListarProveedor()
        {
            SqlCommand cmd = null;
            List<Proveedores> lista = new List<Proveedores>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("listarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Proveedores bo = new Proveedores();
                    bo.idProveedor = Convert.ToInt16(dr["idProveedor"]);
                    bo.nombre = dr["nombre"].ToString();
                    bo.Caracteristica = dr["Caracteristica"].ToString();
                    bo.estado = Convert.ToBoolean(dr["estado"]);
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

        public Boolean InsertarProveedor(Proveedores bol)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", bol.nombre);
                cmd.Parameters.AddWithValue("@caracteristica", bol.Caracteristica);
                cmd.Parameters.AddWithValue("@estado", bol.estado);

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

        public Proveedores BuscarProveedor(int codigo)
        {
            SqlCommand cmd = null;
            Proveedores bol = new Proveedores();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", codigo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    bol.idProveedor = Convert.ToInt16(dr["idProveedor"]);
                    bol.nombre = dr["nombre"].ToString();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return bol;
        }

        public Boolean InhabilitarProveedor (Proveedores bol)
        {
            SqlCommand cmd = null;
            Boolean Inhabilitar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("inhabilitarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", bol.idProveedor);
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
