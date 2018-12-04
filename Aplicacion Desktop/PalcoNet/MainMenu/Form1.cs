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
            switch (funcionalidadId) {
                case 0: {
                    // LOGIN Y SEGURIDAD
                    
                    break;
                }
                case 1:
                {
                    // ABM ROL
                    new Abm_Rol.Form1().Show(this);
                    break;
                }
                case 2:
                {
                    // REGISTRO DE USUARIOS
                    break;
                }
                case 3:
                {
                    //ABM CLIENTES
                    new Abm_Cliente.ListadoClientesForm().ShowDialog(this);
                    break;
                }
                case 4:
                {
                    // ABM EMPRESAS
                    new Abm_Empresa_Espectaculo.ListaEmpresas().Show(this);
                    break;
                }
                case 5:
                {
                    // ABM CATEGORIAS
                    new Abm_Rubro.ListadoRubros().Show(this);
                    break;
                }
                case 6:
                {
                    // ABM GRADO DE PUBLICACION
                    new Abm_Grado.Form1().Show();
                    break;
                }
                case 7:
                {
                    // GENERACION DE ESPECTACULOS 
                    new Generar_Publicacion.Form1().Show();
                    break;
                }
                case 8:
                {
                    // EDITAR PUBLICACIONES
                    new Editar_Publicacion.Form1().Show();
                    break;
                }
                case 9:
                {
                    // COMPRAR
                    new Comprar.Form1().Show();
                    break;
                }
                case 10:
                {
                    // HISTORIAL CLIENTE
                    new Historial_Cliente.Form1().Show();
                    break;
                }
                case 11:
                {
                    // CANJE DE PUNTOS
                    new Canje_Puntos.Form1().Show();
                    break;
                }
                case 12:
                {
                    // GENERAR PAGO DE COMISIONES
                    new Generar_Rendicion_Comisiones.Form1().Show();
                    break;
                }
                case 13:
                {
                    // LISTADO ESTADISTICO
                    new Listado_Estadistico.Form1().Show();
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
