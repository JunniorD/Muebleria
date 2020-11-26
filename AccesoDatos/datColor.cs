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
    public class datColor
    {
        #region singleton
        private static readonly datColor _instancia = new datColor();
        public static datColor Instancia
        {
            get { return datColor._instancia; }
        }
        #endregion singleton

        #region metodos
        public List<Colores> ListarColor()
        {
            SqlCommand cmd = null;
            List<Colores> lista = new List<Colores>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("listarColor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Colores bo = new Colores();
                    bo.CodigoColor = Convert.ToInt16(dr["CodigoColor"]);
                    bo.Nombre = dr["Nombre"].ToString();
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

        public Boolean InsertarColor(Colores bol)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarColor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", bol.Nombre);
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

        #endregion metodos
    }
}
