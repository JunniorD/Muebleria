using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Entidades;

namespace ProyectoMuebleria
{
    public partial class Proveedor : Form
    {
        public Proveedor()
        {
            InitializeComponent();
            ListarDatos();
        }
        public List<Proveedores> ListarDatos()
        {
            List<Proveedores> listadato = LogProveedor.Instancia.ListarProveedor();
            if (listadato.Count > 0)
            {
                BindingSource datosEnlazados = new BindingSource();
                datosEnlazados.DataSource = listadato;
                DatosProveedor.DataSource = datosEnlazados;
            }
            return (listadato);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedores bo = new Proveedores();
                Proveedor formGridBoleta = new Proveedor();
                bo.nombre = txtNombre.Text.Trim();
                bo.Caracteristica = txtCaracteristica.Text.Trim();
                bo.estado = CheckEstado.Checked;

                LogProveedor.Instancia.InsetarProveedor(bo);
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
            Form1 formGridBoleta =
       Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (formGridBoleta != null)
            {
                formGridBoleta.ListarDatos();
                formGridBoleta.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCodigo.Text);
            Proveedores emp = LogProveedor.Instancia.BuscarProveedor(id);
            if (emp != null)
            {
                if (emp.idProveedor == id)
                {
                    txtCodigo.Text = emp.idProveedor.ToString();
                    txtNombre.Text = emp.nombre.ToString();
                }
                else
                {
                    txtCodigo.Text = "";
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
            int id = int.Parse(txtCodigo.Text);
            Proveedores P = LogProveedor.Instancia.BuscarProveedor(id);
            if (P != null)
            {
                try
                {
                    if (P.idProveedor == id)
                    {

                        //Boolean inserta;
                        Proveedores p = new Proveedores();
                        Proveedor formGridBoleta = new Proveedor();
                        p.idProveedor = id;

                        LogProveedor.Instancia.InhabilitarProveedor(p);
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
    }
}
