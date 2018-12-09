using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Dao;
using PalcoNet.Exceptions;
using PalcoNet.Model;
using System.Data;


namespace PalcoNet.Generar_Publicacion
{
    /*
     *  ESTRATEGIA:
     *  - LOS PRECIOS SON POR TIPO DE UBICACION
     *  - LAS UBICACIONES SE PUEDEN HACER POR ZONAS CUADRADAS O RECTANGULARES,
     *      ES DECIR DE LA FILA B A LA D LOS ASIENTOS 1,2 Y 3(TODOS ESTOS
     *      TENDRAN EL MISMO PRECIO) PERO LA A PUEDE TENER OTRO PRECIO
     */
    public partial class AñadirUbicacionForm : Form
    {


        private string precio;
        private string filasDesde;
        private string filasHasta;
        private string asientosDesde;
        private string asientosHasta;

        private bool modificando = false;
        private Ubicacion ubicacionAModificar;


        public delegate void OnFinishNewLocations(List<Ubicacion> ubicaciones);
        public event OnFinishNewLocations onFinishregistration;

        private List<Ubicacion> listaUbicaciones = new List<Ubicacion>();

        public AñadirUbicacionForm()
        {
            InitializeComponent();

            TipoUbicacionDao tipoUbicacionesDao = new TipoUbicacionDao();

            tipoUbicacionesDao.getTipoUbicaciones().ForEach(elem => {
                TipoUbicacionComboBox.Items.Add(elem);
            });
        }

        public AñadirUbicacionForm(Ubicacion ubicacion){
            InitializeComponent();
            this.ubicacionAModificar = ubicacion;
            TipoUbicacionDao dao = new TipoUbicacionDao();
            dao.getTipoUbicaciones().ForEach(elem => {
                TipoUbicacionComboBox.Items.Add(elem);
            });

            this.TipoUbicacionComboBox.SelectedText = ubicacion.tipoUbicaciones.descripcion;
            this.PrecioTextBox.Text = ubicacion.precio.ToString();

            modificando = true;

            this.TipoUbicacionComboBox.SelectedIndex = this.TipoUbicacionComboBox.FindStringExact(ubicacion.tipoUbicaciones.descripcion);
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.label9.Text = "Ubicacion " + ubicacion.fila + "-" + ubicacion.asiento.ToString();
        }

        private void onPriceChanged(object sender, EventArgs e) {
            try
            {
                precio = ((TextBox)sender).Text;
            }
            catch (Exception ex) { }
        }

        private void FilasDesdeTextBox_TextChanged(object sender, EventArgs e)
        {
            filasDesde = ((TextBox)sender).Text;
        }

        private void FilasHastaTextBox_TextChanged(object sender, EventArgs e)
        {
            filasHasta = ((TextBox)sender).Text;
        }

        private void AsientosDesdeTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            try
            {
                int.Parse(text.Last().ToString());
                asientosDesde = text;
            }
            catch (Exception E) {
                if (text.Length > 0) {
                    ((TextBox)sender).Text = text.Remove(text.Length - 1);
                    MessageBox.Show("El numero de asiento debe ser numerico");
                }
                
            }
                
        }

        private void AsientosHastaTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            try
            {
                int.Parse(text.Last().ToString());
                asientosHasta = text;
            }
            catch (Exception E) {
                if (text.Length > 0) {
                    ((TextBox)sender).Text = text.Remove(text.Length - 1);
                    MessageBox.Show("El numero de asiento debe ser numerico");
                }
                
            }   
        }

        private Ubicacion getUbicacionFromDatos() {
            Ubicacion ubicacion = new Ubicacion();

            ubicacion.sinEnumerar = 0;
            ubicacion.precio = int.Parse(precio);
            ubicacion.tipoUbicaciones = (TipoUbicacion)TipoUbicacionComboBox.SelectedItem;

            return ubicacion;
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            Ubicacion ubicacion;
            if (!modificando)
            {
                for (char c = filasDesde[0]; c <= filasHasta[0]; c++)
                {
                    for (int i = int.Parse(asientosDesde); i <= int.Parse(asientosHasta); i++)
                    {
                        ubicacion = getUbicacionFromDatos();
                        ubicacion.fila = c.ToString();
                        ubicacion.asiento = i;

                        listaUbicaciones.Add(ubicacion);

                    }
                }
            }
            else {
                ubicacion = getUbicacionFromDatos();
                ubicacion.fila = ubicacionAModificar.fila;
                ubicacion.asiento = ubicacionAModificar.asiento;
                listaUbicaciones.Add(getUbicacionFromDatos());
            }
            if (onFinishregistration != null)
                this.onFinishregistration(listaUbicaciones);
            this.Close();
        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
