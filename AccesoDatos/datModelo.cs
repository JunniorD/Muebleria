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
    public class datModelo
    {
        #region singleton
        private static readonly datModelo _instancia = new datModelo();
        public static datModelo Instancia
        {
            get { return datModelo._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<Modelos> ListarModelo()
        {
            SqlCommand cmd = null;
            List<Modelos> lista = new List<Modelos>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("listarModelo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Modelos bo = new Modelos();
                    bo.CodigoModelo = Convert.ToInt16(dr["CodigoModelo"]);
                    bo.Nombre = dr["Nombre"].ToString();
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

        public Boolean InsertarModelo(Modelos bol)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarModelo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", bol.Nombre);
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
        #endregion metodos
    }
}
