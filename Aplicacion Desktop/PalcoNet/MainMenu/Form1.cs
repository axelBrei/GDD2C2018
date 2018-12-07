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
            this.iniciarBotones();
            clickHandler(funcionalidades[0].id);
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
                    button.Size = new Size(200, 30);
                    button.Location = new Point(0, cantBotones * 35);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    this.panel1.Controls.Add(button);
                }
                
            }
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
                        form = new Comprar.Form1();
                        break;
                    }
                case 10:
                    {
                        // HISTORIAL CLIENTE
                        form = new Historial_Cliente.Form1();
                        break;
                    }
                case 11:
                    {
                        // CANJE DE PUNTOS
                        form = new Canje_Puntos.Form1();
                        break;
                    }
                case 12:
                    {
                        // GENERAR PAGO DE COMISIONES
                        form = new Generar_Rendicion_Comisiones.Form1();
                        break;
                    }
                case 13:
                    {
                        // LISTADO ESTADISTICO
                        form = new Listado_Estadistico.Form1();
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
            this.panel2.Controls.Add(form);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
