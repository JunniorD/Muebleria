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
   public class LogMaterial
    {
        #region singleton
        private static readonly LogMaterial _instancia = new LogMaterial();
        public static LogMaterial Instancia
        {
            get { return LogMaterial._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<Materiales> ListarMaterial()
        {
            try
            {
                return datMaterial.Instancia.ListarMaterial();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void InsetarMateriales(Materiales ma)
        {
            try
            {
                datMaterial.Instancia.InsertarMateriales(ma);
            }
            catch (Exception e)
            { throw e; }
        }

        public Materiales BuscarMaterial(int id)
        {
            try
            {
                return datMaterial.Instancia.BuscarMaterial(id);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InhabilitarMaterial(Materiales bol)
        {
            try
            {
                return datMaterial.Instancia.InhabilitarMaterial(bol);
            }
            catch (Exception e) { throw e; }
        }



        #endregion metodos
    }
}
