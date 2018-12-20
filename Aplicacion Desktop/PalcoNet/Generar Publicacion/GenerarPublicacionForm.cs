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
using PalcoNet.Exceptions;
using PalcoNet.Dao;
using System.Data;
using PalcoNet.Constants;
using PalcoNet.UserData;
using System.Data.SqlClient;
using PalcoNet.ConectionUtils;
using PalcoNet.Editar_Publicacion;
using PalcoNet.Constants;

namespace PalcoNet.Generar_Publicacion
{
    public partial class GenerarPublicacionForm : Form
    {

        /*
         *  ESTRAGTEGIA:
         *  - TODAS LAS PUBLICACIONES QUE SE AGREGAN ENTRAN EN UN ESTADO DE BORRADOR, LUEGO SE PUEDE MODIFICAR DICHO ESTADO
         *      A FINALIZADA O ACTIVA
         *  - TODA PUBLICACION DEBE TENER UNA CATEOGIRA(RUBRO) DISTINTO DEL DEFAUL "-"
         */ 

        private RubrosDao rubrosDao;
        private GradoDePublicacionDao gradosDao;
        private PublicacionesDao publicacionesDao;
        private EspectaculosDao espectaculosDao;
        private PublicacionesController controller;

        private string direccionPublicacion;
        private string descripcionPublicacion;
        private Rubro rubro;
        private GradoPublicacion gradoPublicacion;
        private List<DateTime> fechasDeLaPublicacion = new List<DateTime>();
        private List<Ubicacion> ubicacionesList = new List<Ubicacion>();
        private DateTime fechaMinima;

        private bool modificandoPublicacion = false;
        public Publicacion publicacionAModificar { get; set; }
        public bool fechaModificada { get; set; }


        public GenerarPublicacionForm()
        {
            InitializeComponent();
            // Dia Minimo: ayer
            
            fechasDeLaPublicacion.Add(Generals.getFecha());
            this.FechaEventoTimePicker.MinDate = Generals.getFechaMinima().Subtract(new TimeSpan(0,1,0,0));
            this.FechaEventoTimePicker.Value = Generals.getFecha();

            initContent();
        }

        public GenerarPublicacionForm(Publicacion publicacion) {
            modificandoPublicacion = true;
            publicacionAModificar = publicacion;
            InitializeComponent();
            // INICIALIZO DATOS COMUNES
            initContent();
            
            // CARGO LOS DATOS DE LA DIRECCION
            direccionPublicacion = publicacion.espectaculo.direccion;
            this.DireccionTextBox.Text = publicacion.espectaculo.direccion;
            // CARGO LOS DATOS DE LA DESCRIPCION
            descripcionPublicacion = publicacion.espectaculo.descripcion;
            this.textBox1.Text = publicacion.espectaculo.descripcion;
            // CARGO LOS DATOS DEL RUBRO
            rubro = publicacion.espectaculo.rubro;
            this.RubroComboBox.SelectedItem = publicacion.espectaculo.rubro;
            // CARGO EL GRADO DE PUBLICACION
            gradoPublicacion = publicacion.gradoPublicacion;
            this.GradoPublicacionComboBox.SelectedItem = publicacion.gradoPublicacion;
            // CARGO LAS UBICACIONES DE LA PUBLICACION
            ubicacionesList = publicacion.ubicaciones;
            publicacion.ubicaciones.ForEach(elem => {
                this.UbicacionesListView.Items.Add(getItemDeUbicacion(elem));
            });
            // CARGO LOS DATOS DE LAS FECHAS

            fechasDeLaPublicacion.Add( (DateTime) publicacion.fechaEvento);

            //fechaMinima = Generals.getFecha();
            //this.FechaEventoTimePicker.MinDate = Generals.getFecha().Subtract(new TimeSpan(0,1,0,0));
            this.FechaEventoTimePicker.Value = (DateTime) publicacion.fechaEvento;
            this.HoraEventoTimePicker.Value = ((DateTime)publicacion.fechaEvento);

            this.button2.Visible = false;
            this.ClearFormButton.Visible = false;

            this.button1.Visible = false;
            this.EliminarUbicacionButton.Visible = false;
            this.UbicacionesPanel.Visible = false;
            this.AceptarButton.Visible = false;

            
        }

        private void initContent() {
            rubrosDao = new RubrosDao();
            gradosDao = new GradoDePublicacionDao();
            publicacionesDao = new PublicacionesDao();
            espectaculosDao = new EspectaculosDao();
            controller = new PublicacionesController();

            rubrosDao.getRubros().Skip(1).ToList().ForEach(
                elem => RubroComboBox.Items.Add(elem)
            );

            this.FechaEventoTimePicker.ShowUpDown = false;
            this.FechaEventoTimePicker.CustomFormat = "yyyy.MM.dd";

            gradosDao.getGradosDePublicacion().ForEach(elem =>
            {
                GradoPublicacionComboBox.Items.Add(elem);
            });
            GradoPublicacionComboBox.Items.RemoveAt(GradoPublicacionComboBox.Items.Count - 1);
            this.UbicacionesListView.Columns.Insert(0, "Fila", 5 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(1, "Asiento", 5 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(2, "Tipo de Ubicacion", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(3, "Precio", 15 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.UbicacionesListView.Columns.Insert(4, "Numerada", 10 * (int)UbicacionesListView.Font.SizeInPoints, HorizontalAlignment.Center);
        }
 

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DireccionTextBox_TextChanged(object sender, EventArgs e)
        {
            direccionPublicacion = ((TextBox)sender).Text;
            if (modificandoPublicacion) {
                publicacionAModificar.espectaculo.direccion = ((TextBox)sender).Text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            descripcionPublicacion = ((TextBox)sender).Text;
            if (modificandoPublicacion) {
                publicacionAModificar.espectaculo.descripcion = ((TextBox)sender).Text;
            }
        }

        private void FechaEventoTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var timePicker = sender as DateTimePicker;
            try
            {
                DateTime time = this.FechaEventoTimePicker.Value;
                fechasDeLaPublicacion.RemoveAt(0);
                fechasDeLaPublicacion.Insert(0, time);
                fechaMinima = time;
                if (modificandoPublicacion) {
                    fechaModificada = DateTime.Compare(fechaMinima, (DateTime)publicacionAModificar.fechaEvento) != 0;
                    publicacionAModificar.fechaEvento = time;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void HoraEventoTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker horas = sender as DateTimePicker;
                DateTime fecha = fechasDeLaPublicacion[0].Date; 

                fecha = fecha.AddHours(horas.Value.Hour);
                fecha = fecha.AddMinutes(horas.Value.Minute);

                fechasDeLaPublicacion.RemoveAt(0);
                fechasDeLaPublicacion.Insert(0, fecha);
                if (modificandoPublicacion) {
                    fechaModificada = DateTime.Compare(fecha, (DateTime)publicacionAModificar.fechaEvento) != 0;
                    publicacionAModificar.fechaEvento = fecha;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void RubroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox lista = sender as ComboBox;
            try
            {
                rubro = (Rubro)lista.SelectedItem;
                if (modificandoPublicacion) {
                    publicacionAModificar.espectaculo.rubro = rubro;
                }
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AñadirUbicacionForm form = new AñadirUbicacionForm();
            form.onFinishregistration += this.onFinishLocationInsertions;
            form.Show(this);
        }

        private ListViewItem getItemDeUbicacion(Ubicacion elem) {
            ListViewItem item = new ListViewItem();
            item.Text = elem.fila.ToUpper();
            item.SubItems.Add(elem.asiento.ToString());
            item.SubItems.Add(elem.tipoUbicaciones.descripcion);
            item.SubItems.Add("$" + elem.precio.ToString());
            item.SubItems.Add(elem.sinEnumerar == 1 ? "No" : "Si");

            item.Tag = elem;

            return item;
        }

        private void onFinishLocationInsertions(List<Ubicacion> ubicaciones) {
            string filasDuplicadas = "";
            foreach (Ubicacion elem in ubicaciones) {
                if (ubicacionesList.Contains(elem))
                {
                    if (!filasDuplicadas.Contains(elem.fila))
                        filasDuplicadas += elem.fila + "-" + elem.asiento + ", ";
                    continue;
                }
                UbicacionesListView.Items.Add(getItemDeUbicacion(elem));
            }
            if (!string.IsNullOrEmpty(filasDuplicadas)) {
                if (filasDuplicadas.Length % 2 == 0)
                    filasDuplicadas = filasDuplicadas.Remove(filasDuplicadas.Length - 1);
                MessageBox.Show("No se pudieron insertar las filas y asientos porque ya estan asignados\n Filas: " + filasDuplicadas.ToUpper());
            }
            ubicaciones.ForEach(elem => {
                if (!ubicacionesList.Contains(elem)) {
                    ubicacionesList.Add(elem);
                }
            });
        }

        private void EliminarUbicacionButton_Click(object sender, EventArgs e)
        {
            try
            {
                UbicacionesListView.Items.Remove(UbicacionesListView.SelectedItems[0]);
                ubicacionesList.Remove((Ubicacion)UbicacionesListView.Items[0].Tag);
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AñadirFechasForm form = new AñadirFechasForm(fechasDeLaPublicacion[0]);
            if (fechasDeLaPublicacion.Count > 1)
                form = new AñadirFechasForm(fechasDeLaPublicacion[0], fechasDeLaPublicacion.Skip(1).OrderBy( elem => elem).ToList());
            form.onFinishDateInsertion += this.onFinishDateInsertion;
            form.Show(this);
        }

        private void onFinishDateInsertion(List<DateTime> lista, bool modificando) {
            if (!modificando)
            {
                lista.ForEach(elem =>
                {
                    fechasDeLaPublicacion.Add(elem);
                });
            }
            else {
                for (int i = 1; i < lista.Count; i++) {
                    fechasDeLaPublicacion.RemoveAt(i);
                    fechasDeLaPublicacion.Insert(i, lista[i]);
                }
            }
            
        }

        private void GradoPublicacionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gradoPublicacion = (GradoPublicacion)GradoPublicacionComboBox.SelectedItem;
                if (modificandoPublicacion) {
                    publicacionAModificar.gradoPublicacion = gradoPublicacion;
                }
            }
            catch (Exception ex) { } 
        }
        private bool espectGenerado = false;
        private Espectaculo espec;

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if(rubro == null || (rubro != null && rubro.descripcion.Equals("-"))){
                    MessageBox.Show("Debe seleccionar una categoria para el espectaculo");
            }else if(ubicacionesList.Count == 0){
                MessageBox.Show("Debe ingresar por lo menos una ubicacion");
            }else{
                if (!modificandoPublicacion)
                {
                    Empresa empre = new Empresa();
                    Usuario user = UserData.UserData.getUsuario();
                    if (user.usuarioRegistrable.getTipo() == UserData.UserData.TIPO_EMPRESA)
                    {
                        empre.id = ((Empresa)UserData.UserData.getClieOEmpresa()).id;
                        insertarPublicacionEnDB(empre);
                    }
                    else {
                        SeleccionarEmpresa form = new SeleccionarEmpresa();
                        form.onFinisCompanySelection += this.onSelectCompany;
                        form.Show(this);
                    }
                    
                }
                else { 
                    /*
                     * ESTRATEGIA MODIFICACION:
                     *  - UNA PUBLICACION SIEMRPE TENDRA EL MISMO ESPCTACULO-
                     *  - UNA UBICACION QUE NO ESTA DISPONIBLE NO SE PUEDE HABILITAR, TAMPOCO AL REVEZ
                     *  - 
                    */


                    // TODO: METODO PARA UPDATEAR LA PUBLICACION EN LA BASE DE DATOS
                    // PONER UN EVENT HANDLER PARA AVISARLE AL PADRE QUE SE ACTUALIZA LA PUBLICACION
                }
            }
        }

        private void onSelectCompany(Empresa empre) {
            insertarPublicacionEnDB(empre);
        }

        private void insertarPublicacionEnDB(Empresa empre) {
            SqlTransaction transaction = DatabaseConection.getInstance().BeginTransaction();
            if (espectGenerado == false)
            {
                espec = new Espectaculo();
                espec.descripcion = descripcionPublicacion;
                espec.direccion = direccionPublicacion;
                espec.rubro = rubro;
                espec.empresa = empre;
                espectGenerado = true;                
                espec.id = espectaculosDao.insertarEspectaculo(espec, transaction);

            }
            try
            {
                fechasDeLaPublicacion.ForEach(elem =>
                {
                    Publicacion publicacion = new Publicacion();
                    publicacion.gradoPublicacion = gradoPublicacion;
                    publicacion.fechaEvento = elem;
                    publicacion.fechaPublicacion = Generals.getFecha();
                    publicacion.estado = Strings.ESTADO_BORRADOR;
                    publicacion.espectaculo = espec;
                    publicacion.ubicaciones = ubicacionesList;

                    controller.insertarPublicacionEnDB(publicacion, transaction);
                });
                transaction.Commit();
                MessageBox.Show("Se ha cargado la publicación");
                borrarFormulario();
                espectGenerado = false;
            }
            catch (SqlInsertException ex)
            {
                transaction.Rollback();
                MessageBox.Show("Ha ocurrido un error al intentar cargar la/s publicacion/es.");
            }
        }

        private void borrarFormulario() {
            this.FechaEventoTimePicker.Value = Generals.getFecha().Subtract(new TimeSpan(1, 0, 0, 0)).Date;
            this.DireccionTextBox.Text = "";
            this.RubroComboBox.SelectedItem = null;
            this.GradoPublicacionComboBox.SelectedItem = null;
            this.UbicacionesListView.Items.Clear();
            this.textBox1.Text = "";

            this.ubicacionesList.Clear();
            this.fechasDeLaPublicacion.Clear();
            this.fechasDeLaPublicacion.Add(Generals.getFecha());
            direccionPublicacion = "";
            rubro = null;
            gradoPublicacion = null;
            descripcionPublicacion = "";
        }

        private void ClearFormButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha limpiado el formulario");
            borrarFormulario();
        }
    }
}
