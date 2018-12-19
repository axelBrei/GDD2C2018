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
using PalcoNet.Constants;

namespace PalcoNet.Canje_Puntos
{
    public partial class PuntosForm : Form
    {

        private PremiosListForm premiosForm;
        private Cliente cliente;

        public delegate void OnBackPress();
        public event OnBackPress onBackPress;

        public PuntosForm(Cliente cli)
        {
            InitializeComponent();
            cliente = cli;

            premiosForm = new PremiosListForm(cli);
            premiosForm.TopLevel = false;
            premiosForm.AutoScroll = true;
            premiosForm.Parent = this.Parent;
            premiosForm.onCanjePress += this.onCanjePuntos;
            this.PuntosPanel.Controls.Add(premiosForm);
            premiosForm.Show();
            

            if (cli.puntos == 0) { 
                // MOSTRARLE AL USUARIO QUE NO TIENE PUNTOS
                this.VencimientoLabel.Visible = false;
                this.VencimientoTextLabel.Visible = false;
                this.PuntosTextLabel.Text = "No posee puntos para canjear";
                this.PuntosLabel.Visible = false;
                premiosForm.CanjearButton.Enabled = false;
            }
            else if (DateTime.Compare((DateTime)cli.vencimientoPuntos, Generals.getFecha()) < 0)
            {
                // PUNTOS VENCIDOS
                premiosForm.CanjearButton.Enabled = false;
                this.VencimientoTextLabel.Text = "Puntos Vencidos el:";
                this.PuntosLabel.Text = cliente.puntos.ToString();
                this.VencimientoLabel.Text = ((DateTime)cliente.vencimientoPuntos).ToShortDateString();
            }
            else { 
                // MOSTRAR LISTA DE PUNTOS
                this.PuntosLabel.Text = cliente.puntos.ToString();
                this.VencimientoLabel.Text = ((DateTime)cliente.vencimientoPuntos).ToShortDateString();
            }

    
        }

        private void onBackBtnPress(object sender,EventArgs e){
            if (this.onBackPress != null)
                this.onBackPress();
        }

        private void insertarBottonVolverListaClientes() {
            Button btn = new Button();
            btn.Size = new Size(90, 25);
            btn.ForeColor = Color.White;
            btn.BackColor = SystemColors.Desktop;
            btn.Location = new Point(613, 463);
            btn.Text = "Volver";
            btn.Click += this.onBackBtnPress;

            this.PuntosPanel.Controls.Add(btn);
        }

        private void onCanjePuntos(int puntosRestados) {
            this.PuntosLabel.Text = ((int)cliente.puntos - puntosRestados).ToString();
        }

        private void PuntosForm_Load(object sender, EventArgs e)
        {
            if (this.onBackPress != null)
                insertarBottonVolverListaClientes();
        }
    }
}
