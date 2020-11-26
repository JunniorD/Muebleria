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
    public partial class Material : Form
    {
        public Material()
        {
            InitializeComponent();
            ListarMaterial();
        }
        public List<Materiales> ListarMaterial()
        {
            List<Materiales> listadato = LogMaterial.Instancia.ListarMaterial();
            if (listadato.Count > 0)
            {
                BindingSource datosEnlazados = new BindingSource();
                datosEnlazados.DataSource = listadato;
                dataGridView1.DataSource = datosEnlazados;
            }
            return (listadato);
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Materiales bo = new Materiales();
                Material formGridBoleta = new Material();
                bo.nombre = txtNombre.Text.Trim();
                bo.tipo = TxtTipo.Text.Trim();
                bo.Estado = CheckEstado.Checked;

                LogMaterial.Instancia.InsetarMateriales(bo);
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
            Material formGridBoleta =
       Application.OpenForms.OfType<Material>().FirstOrDefault();
            if (formGridBoleta != null)
            {
                formGridBoleta.ListarMaterial();
                formGridBoleta.Refresh();
            }
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCodigo.Text);
            Materiales emp = LogMaterial.Instancia.BuscarMaterial(id);
            if (emp != null)
            {
                if (emp.idMaterial == id)
                {
                    TxtCodigo.Text = emp.idMaterial.ToString();
                    txtNombre.Text = emp.nombre.ToString();
                }
                else
                {
                    TxtCodigo.Text = "";
                    txtNombre.Text = "";
                    MessageBox.Show("Los datos no existen, verifique");

                }
            }

            else
            {
                MessageBox.Show("Los datos no existen, verifique");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCodigo.Text);
            Materiales P = LogMaterial.Instancia.BuscarMaterial(id);
            if (P != null)
            {
                try
                {
                    if (P.idMaterial == id)
                    {

                        //Boolean inserta;
                        Materiales p = new Materiales();
                        Material formGridBoleta = new Material();
                        p.idMaterial = id;

                        LogMaterial.Instancia.InhabilitarMaterial(p);
                        MessageBox.Show("Los datos ham sido eliminados con exito");
                        //   Close();
                        ActualizarGridDatos();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
