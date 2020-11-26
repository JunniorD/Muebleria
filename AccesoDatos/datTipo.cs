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
  public  class datTipo
    {
        #region singleton
        private static readonly datTipo _instancia = new datTipo();
        public static datTipo Instancia
        {
            get { return datTipo._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<Tipos> ListarTipo()
        {
            SqlCommand cmd = null;
            List<Tipos> lista = new List<Tipos>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("listarTipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Tipos bo = new Tipos();
                    bo.CodigoTipo = Convert.ToInt16(dr["CodigoTipo"]);
                    bo.Nombre = dr["Nombre"].ToString();
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

        public Boolean InsertarTipo(Tipos bol)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarTipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", bol.Nombre);
                cmd.Parameters.AddWithValue("@Caracteristica", bol.Caracteristica);
                cmd.Parameters.AddWithValue("@Estado", bol.estado);

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

        #endregion metodos

    }
}
