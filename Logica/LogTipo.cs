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
   public class LogTipo
    {
        #region singleton
        private static readonly LogTipo _instancia = new LogTipo();
        public static LogTipo Instancia
        {
            get { return LogTipo._instancia; }
        }
        #endregion singleton

        #region metodos

        public List<Tipos> ListaTipo()
        {
            try
            {
                return datTipo.Instancia.ListarTipo();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void InsetarTipo(Tipos pro)
        {
            try
            {
                datTipo.Instancia.InsertarTipo(pro);
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion metodos

    }
}
