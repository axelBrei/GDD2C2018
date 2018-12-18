using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.UserData;
using PalcoNet.Model;
using PalcoNet.Dao;

namespace PalcoNet.MainMenu
{
    public partial class Form1 : Form
    {
        Usuario usuario = null;
        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

        public Form1()
        {
            InitializeComponent();

            usuario = UserData.UserData.getUsuario();

            FuncionalidadesDao funcionalidadesDao = new FuncionalidadesDao();
            funcionalidades = funcionalidadesDao.getFuncionalidades();
            this.panel2.Parent = this;
            this.iniciarBotones();
            
        }

        private void iniciarBotones() {
            int cantBotones = 0;
            Rol rol = UserData.UserData.getRolActivo();
            foreach (Funcionalidad fun in rol.funcionalidades)
            {
                if (fun.descripcion != "Registro de Usuarios") {
                    cantBotones++;
                    Button button = new Button();
                    button.Text = fun.descripcion;
                    button.Click += (se, ev) => this.getClickHandler(se, ev, fun.id);
                    button.Size = new Size(200, 50);
                    button.Location = new Point(0, (cantBotones - 1) * 45);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.ForeColor = Color.White;
                    button.Font = new Font(FontFamily.GenericSansSerif, 10.0f, FontStyle.Bold);
                    this.panel1.Controls.Add(button);
                }
            }
            clickHandler(rol.funcionalidades[0].id);
        }

        protected void getClickHandler(object sender, EventArgs e, int funcionalidadId)
        {
            clickHandler(funcionalidadId);
        }

        private void clickHandler(int funcionalidadId) {
            this.panel2.Controls.Clear();
            Form form = null;
            switch (funcionalidadId)
            {
                case 1:
                    {
                        // ABM ROL
                        form = new Abm_Rol.Form1();
                        break;
                    }
                case 3:
                    {
                        //ABM CLIENTES
                        form = new Abm_Cliente.ListadoClientesForm();
                        break;
                    }
                case 4:
                    {
                        // ABM EMPRESAS
                        form = new Abm_Empresa_Espectaculo.ListaEmpresas();
                        break;
                    }
                case 5:
                    {
                        // ABM CATEGORIAS
                        form = new Abm_Rubro.ListadoRubros();
                        break;
                    }
                case 6:
                    {
                        // ABM GRADO DE PUBLICACION
                        form = new Abm_Grado.ListaGradosDePublicacion();
                        break;
                    }
                case 7:
                    {
                        // GENERACION DE ESPECTACULOS 
                        form = new Generar_Publicacion.GenerarPublicacionForm();
                        break;
                    }
                case 8:
                    {
                        // EDITAR PUBLICACIONES
                        form = new Editar_Publicacion.ListaPublicacionesForm();
                        break;
                    }
                case 9:
                    {
                        // COMPRAR
                        form = new Comprar.ListadoPublicacionesComprasForm();
                        break;
                    }
                case 10:
                    {
                        // HISTORIAL CLIENTE
                        if (usuario.usuarioRegistrable.getTipo() == UserData.UserData.TIPO_CLIENTE)
                        {
                            form = new Historial_Cliente.HistorialCliente(usuario.usuarioRegistrable.getId());
                        }
                        else {
                            Historial_Cliente.SeleccionarClienteForm selecCliForm = new Historial_Cliente.SeleccionarClienteForm();
                            selecCliForm.onSelectClient += this.onClienteSeleccionado;
                            form = selecCliForm;
                        }
                        
                        break;
                    }
                case 11:
                    {
                        // CANJE DE PUNTOS
                        if (usuario.usuarioRegistrable.getTipo() == UserData.UserData.TIPO_CLIENTE)
                        {
                            form = new Canje_Puntos.PuntosForm((Cliente)UserData.UserData.getClieOEmpresa());
                        }
                        else {
                            Historial_Cliente.SeleccionarClienteForm t = new Historial_Cliente.SeleccionarClienteForm();
                            t.onSelectClient += this.onClientSeleccionadoPuntos;
                            form = t;
                        }

                        
                        break;
                    }
                case 12:
                    {
                        // GENERAR PAGO DE COMISIONES
                        form = new Generar_Rendicion_Comisiones.GenerarComisionesForm();
                        break;
                    }
                case 13:
                    {
                        // LISTADO ESTADISTICO
                        form = new Listado_Estadistico.ListadoForm();
                        break;
                    }
                default: {
                    if (funcionalidadId < 12) {
                        clickHandler(funcionalidadId + 1);
                    }
                    break;
                }
            }
            if (form != null)
                showNestedForm(form);
        }

        private void showNestedForm(Form form) {
            form.TopLevel = false;
            form.AutoScroll = true;
            form.Parent = this.Parent;
            this.panel2.Controls.Add(form);
            form.Show();
        }

        private void onClienteSeleccionado(int id) {
            this.panel2.Controls.Clear();
            Historial_Cliente.HistorialCliente form = new Historial_Cliente.HistorialCliente(id, 1);
            form.onBackPress += this.onBackPressComprasDelCliente;
            showNestedForm(form);

        }

        private void onClientSeleccionadoPuntos(int id) {
            this.panel2.Controls.Clear();
            ClientesDao dao = new ClientesDao();
            Canje_Puntos.PuntosForm form = new Canje_Puntos.PuntosForm(dao.getClientePorId(id));
            form.onBackPress += this.onBackPressPuntos;
            showNestedForm(form);
        }

        private void onBackPressPuntos() {
            this.panel2.Controls.Clear();
            Historial_Cliente.SeleccionarClienteForm form = new Historial_Cliente.SeleccionarClienteForm();
            form.onSelectClient += this.onClientSeleccionadoPuntos;
            showNestedForm(form);
        }

        private void onBackPressComprasDelCliente()
        {
            this.panel2.Controls.Clear();
            Historial_Cliente.SeleccionarClienteForm form = new Historial_Cliente.SeleccionarClienteForm();
            form.onSelectClient += this.onClienteSeleccionado;
            showNestedForm(form);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CerrarSesionButton_Click(object sender, EventArgs e)
        {
            PalcoNet.Form1 loginForm = new PalcoNet.Form1();
            loginForm.Show();
            this.Close();
        }
    }
}
