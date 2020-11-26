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
    public partial class Tipo : Form
    {
        public Tipo()
        {
            InitializeComponent();
            ListaTipo();
        }
        public List<Tipos> ListaTipo()
        {
            List<Tipos> listadato = LogTipo.Instancia.ListaTipo();
            if (listadato.Count > 0)
            {
                BindingSource datosEnlazados = new BindingSource();
                datosEnlazados.DataSource = listadato;
                dataGridView1.DataSource = datosEnlazados;
            }
            return (listadato);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Tipos bo = new Tipos();
                Tipo formGridBoleta = new Tipo();
                bo.Nombre = txtNombre.Text.Trim();
                bo.Caracteristica = txtCaracteristica.Text.Trim();
                bo.estado = CheckEstado.Checked;

                LogTipo.Instancia.InsetarTipo(bo);
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
            Tipo formGridBoleta =
       Application.OpenForms.OfType<Tipo>().FirstOrDefault();
            if (formGridBoleta != null)
            {
                formGridBoleta.ListaTipo();
                formGridBoleta.Refresh();
            }
        }

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
