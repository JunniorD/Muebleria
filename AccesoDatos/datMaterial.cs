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
   public class datMaterial
    {
        #region singleton
        private static readonly datMaterial _instancia = new datMaterial();
        public static datMaterial Instancia
        {
            get { return datMaterial._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<Materiales> ListarMaterial()
        {
            SqlCommand cmd = null;
            List<Materiales> lista = new List<Materiales>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("listarMateriales", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Materiales bo = new Materiales();
                    bo.idMaterial = Convert.ToInt16(dr["idMaterial"]);
                    bo.nombre = dr["nombre"].ToString();
                    bo.tipo = dr["tipo"].ToString();
                    bo.Estado = Convert.ToBoolean(dr["estado"]);
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
        public Boolean InsertarMateriales(Materiales bol)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarMateriales", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", bol.nombre);
                cmd.Parameters.AddWithValue("@tipo", bol.tipo);
                cmd.Parameters.AddWithValue("@estado", bol.Estado);

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

        public Materiales BuscarMaterial(int id)
        {
            SqlCommand cmd = null;
            Materiales bol = new Materiales();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarMateriales", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMaterial", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    bol.idMaterial = Convert.ToInt16(dr["idMaterial"]);
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

        public Boolean InhabilitarMaterial(Materiales bol)
        {
            SqlCommand cmd = null;
            Boolean Inhabilitar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("inhabilitarMaterial", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMaterial", bol.idMaterial);
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
