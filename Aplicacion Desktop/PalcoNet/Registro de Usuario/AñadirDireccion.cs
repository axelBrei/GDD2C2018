using System;
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

        private string tipoDireccion;

        public delegate void GetDirectioonHandler(Direccion dir);
        public event GetDirectioonHandler getDireccion;

        public static string TIPO_CLIENTE = "CLIENTE";
        public static string TIPO_EMPRESA = "EMPRESA";

        public AñadirDireccion(string tipo)
        {
            InitializeComponent();
            tipoDireccion = tipo;

            if (tipo.Equals(TIPO_CLIENTE)) {
                DirCiudad.Visible = false;
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
            this.Close();
        }
    }
}
