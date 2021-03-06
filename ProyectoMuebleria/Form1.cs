﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ListarDatos();
        }
        public List<Producto> ListarDatos()
        {
            List<Producto> listadato = LogProducto.Instancia.ListarProducto();
            if (listadato.Count > 0)
            {
                BindingSource datosEnlazados = new BindingSource();
                datosEnlazados.DataSource = listadato;
                datosProducto.DataSource = datosEnlazados;
            }
            return (listadato);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto bo = new Producto();
                Form1 formGridBoleta = new Form1();
                bo.Nombre = txtNombre.Text.Trim();
                bo.Calidad = txtCalidad.Text.Trim();
                bo.Estado = checkEstado.Checked;

                LogProducto.Instancia.InsetarProducto(bo);
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

        private void BtbBuscar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCodigo.Text);
            Producto emp = LogProducto.Instancia.BuscarProducto(id);
            if (emp != null)
            {
                if (emp.Codigo == id)
                {
                    txtCodigo.Text = emp.Codigo.ToString();
                    txtNombre.Text = emp.Nombre.ToString();
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

        private void BtbEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCodigo.Text);
            Producto P = LogProducto.Instancia.BuscarProducto(id);
            if (P != null)
            {
                try
                {
                    if (P.Codigo == id)
                    {

                        //Boolean inserta;
                        Producto p = new Producto();
                        Form1 formGridBoleta = new Form1();
                        p.Codigo = id;

                        LogProducto.Instancia.InhabilitarProducto(p);
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Form formulario = new Principal();
            formulario.Show();
    
        }
    }
}
