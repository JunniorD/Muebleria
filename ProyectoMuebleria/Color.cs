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
    public partial class Color : Form
    {
        public Color()
        {
            InitializeComponent();
            ListaTipo();
        }
        public List<Colores> ListaTipo()
        {
            List<Colores> listadato = LogoColor.Instancia.ListaColor();
            if (listadato.Count > 0)
            {
                BindingSource datosEnlazados = new BindingSource();
                datosEnlazados.DataSource = listadato;
                DatosColor.DataSource = datosEnlazados;
            }
            return (listadato);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Colores bo = new Colores();
                Color formGridBoleta = new Color();
                bo.Nombre = txtNombre.Text.Trim();
                bo.Estado = checEstado.Checked;

                LogoColor.Instancia.InsetarColor(bo);
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
            Color formGridBoleta =
       Application.OpenForms.OfType<Color>().FirstOrDefault();
            if (formGridBoleta != null)
            {
                formGridBoleta.ListaTipo();
                formGridBoleta.Refresh();
            }
        }
    }
}
