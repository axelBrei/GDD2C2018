﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Model;
using PalcoNet.Dao;
using PalcoNet.Validators;


namespace PalcoNet.Registro_de_Usuario
{
    public partial class AñadirDireccion : Form
    {

        private string calle;
        private string piso;
        private string depto;
        private string localidad;
        private string codigoPostal;
        private string ciudad;
        private string altura;

        private string tipoDireccion;

        public delegate void GetDirectioonHandler(Direccion dir);
        public event GetDirectioonHandler getDireccion;

        private readonly ErrorProvider errorProveide = new ErrorProvider();

        public static string TIPO_CLIENTE = "CLIENTE";
        public static string TIPO_EMPRESA = "EMPRESA";

        public AñadirDireccion(string tipo, Direccion dir) {
            InitializeComponent();
            tipoDireccion = tipo;
            if (dir == null)
                dir = new Direccion();

            DirCalle.Text = dir.calle;
            DirPiso.Text = dir.piso;
            DirDepto.Text = dir.depto;
            DirLocalidad.Text = dir.localidad;
            CodPostalDireccion.Text = dir.codigoPostal;
            AlturaDireccion.Text = dir.numero;
            if (tipo.Equals(TIPO_EMPRESA)) {
                DirCiudad.Text = dir.ciudad;
            }


            if (tipo.Equals(TIPO_CLIENTE))
            {
                DirCiudad.Visible = false;
                DirCiudadLabel.Visible = false;
            }
        }

        public AñadirDireccion(string tipo)
        {
            InitializeComponent();
            tipoDireccion = tipo;

            if (tipo.Equals(TIPO_CLIENTE)) {
                DirCiudad.Visible = false;
                DirCiudadLabel.Visible = false;
            }

            
        }

        private void DirCalle_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            calle = textBox.Text;

        }

        private void DirPiso_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            piso = textBox.Text;
        }

        private void DirDepto_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            depto = textBox.Text;
        }

        private void DirLocalidad_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            localidad = textBox.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            codigoPostal = textBox.Text;
        }

        private void DirCiudad_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ciudad = textBox.Text;
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (calle != null & piso != null & depto != null & localidad != null & codigoPostal != null)
            {
                if (tipoDireccion == TIPO_EMPRESA && ciudad == null)
                {
                    MessageBoxButtons alert = MessageBoxButtons.OK;
                    MessageBox.Show("Debe completar todos los campos para continuar", "Formulario invalido", alert);
                }
                else if (this.getDireccion != null)
                {
                    Direccion direccion = new Direccion();
                    direccion.calle = calle;
                    direccion.piso = piso;
                    direccion.depto = depto;
                    direccion.localidad = localidad;
                    direccion.codigoPostal = codigoPostal;
                    direccion.ciudad = ciudad;
                    direccion.numero = altura;

                    this.getDireccion(direccion);
                    this.Close();
                }
            }
            else {
                MessageBoxButtons alert = MessageBoxButtons.OK;
                MessageBox.Show("Debe completar todos los campos para continuar","Formulario invalido", alert);
            }

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AlturaDireccion_TextChanged(object sender, EventArgs e)
        {
            altura = ((TextBox)sender).Text;
        }

        // ----------------- VALIDACIONES DEL FORMULARIO --------------------------------

        private void AlturaDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.esNumerico(AlturaDireccion.Text.Trim())) {
                errorProveide.SetError(AlturaDireccion, "La altura debe ser un valor numerico unicamente");
                e.Cancel = true;
            }
        }

        private void CodPostalDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.esNumerico(CodPostalDireccion.Text.Trim()))
            {
                errorProveide.SetError(CodPostalDireccion, "La altura debe ser un valor numerico unicamente");
                e.Cancel = true;
            }
        }

        private void DirPiso_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.esNumerico(DirPiso.Text.Trim()))
            {
                errorProveide.SetError(DirPiso, "La altura debe ser un valor numerico unicamente");
                e.Cancel = true;
            }
        }

    }
}
