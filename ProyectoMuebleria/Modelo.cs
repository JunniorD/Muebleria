using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Logica;

namespace ProyectoMuebleria
{
    public partial class Modelo : Form
    {
        public Modelo()
        {
            InitializeComponent();
            ListaModelo();
        }
        public List<Modelos> ListaModelo()
        {
            List<Modelos> listadato = LogModelo.Instancia.ListarModelo();
            if (listadato.Count > 0)
            {
                BindingSource datosEnlazados = new BindingSource();
                datosEnlazados.DataSource = listadato;
                DatosModelo.DataSource = datosEnlazados;
            }
            return (listadato);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Modelos bo = new Modelos();
                Modelo formGridBoleta = new Modelo();
                bo.Nombre = txtNombre.Text.Trim();
                bo.estado = checkEstado.Checked;

                LogModelo.Instancia.InsetarModelo(bo);
                MessageBox.Show("Los Datos son Registrados con exito");
                ActualizarGridDatos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ActualizarGridDatos()
        {
            Modelo formGridBoleta =
       Application.OpenForms.OfType<Modelo>().FirstOrDefault();
            if (formGridBoleta != null)
            {
                formGridBoleta.ListaModelo();
                formGridBoleta.Refresh();
            }
        }
    }
}
