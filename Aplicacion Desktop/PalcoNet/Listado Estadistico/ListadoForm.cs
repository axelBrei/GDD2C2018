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
using PalcoNet.Constants;
using PalcoNet.Dao;

namespace PalcoNet.Listado_Estadistico
{
    public partial class ListadoForm : Form
    {
        private string añoSeleccionado;
        private string TrimestreSeleccionado;
        private EstadisticasDao estadisticasDao;

        public ListadoForm()
        {
            InitializeComponent();
            estadisticasDao = new EstadisticasDao();

            for (int i = Generals.getFecha().Year + 1; i >= 2000; i--)
            {
                this.AñoComboBox.Items.Add(i.ToString());
            }

            new GradoDePublicacionDao().getGradosDePublicacion().ForEach(elem => {
                this.gradoComboBox.Items.Add(elem);
            });
            this.gradoComboBox.SelectedIndex = 1;
            this.AñoComboBox.SelectedIndex = 0;
            this.TrimestreComboBox.SelectedIndex = 0;
            this.EstadisticaComboBox.SelectedIndex = 0;
        }

        private void EstadisticaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.EstadisticaComboBox.SelectedIndex == 0)
            {
                this.gradoLabel.Visible = true;
                this.gradoComboBox.Visible = true;
            }
            else {
                this.gradoLabel.Visible = false;
                this.gradoComboBox.Visible = false;
            }
               

            try
            {
                int año;
                try
                {
                    año = int.Parse(this.AñoComboBox.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    año = int.Parse("2018");
                }
                int trimestre;
                try
                {
                    trimestre = int.Parse(this.TrimestreComboBox.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    trimestre = int.Parse("1");
                }
                DateTime firstDayOfQuarter = new DateTime(año, (trimestre - 1) * 3 + 1, 1);
                DateTime lastDayOfQuarter = firstDayOfQuarter.AddMonths(3).AddDays(-1);
                int grado = ((GradoPublicacion)this.gradoComboBox.SelectedItem).id;
                actualizarLista(firstDayOfQuarter, lastDayOfQuarter, grado);
            }
            catch (Exception ex) { 
                
            }

        }

        private void actualizarLista(DateTime fechaIncio, DateTime fechaFin, Nullable<int> gradoId = null) {
            this.toplistView.BeginUpdate();
            this.toplistView.Columns.Clear();
            this.toplistView.Items.Clear();
            switch (this.EstadisticaComboBox.SelectedIndex) {
                case 0: {
                    this.prepararTop5EmpresasLocalidadesNoVendidas(fechaIncio, fechaFin, (int)gradoId);
                    break;
                }
                case 1: {
                    this.prepararTop5ClientesPuntosVencidos(fechaIncio, fechaFin);
                    break;
                }

                case 2: {
                    this.prepararTop5ClientesConMayoresCompras(fechaIncio, fechaFin);
                    break;
                }
            }
            this.toplistView.EndUpdate();
        }

        private void prepararTop5EmpresasLocalidadesNoVendidas(DateTime fechaInicio, DateTime fechaFin, int gradoId) {
            this.toplistView.Columns.Insert(0, "Empresa", 35 * (int)toplistView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.toplistView.Columns.Insert(1, "Cantidad localidades no vendidas", 20 * (int)toplistView.Font.SizeInPoints, HorizontalAlignment.Center);
            estadisticasDao.getTop5EmpresasConMayorLocalidadesNoVendidas(fechaInicio, fechaFin, gradoId,
                result => {
                    result.ForEach(elem => {
                        this.toplistView.Items.Add(getItemFromEst(elem));
                    });
                });
        }

        private void prepararTop5ClientesPuntosVencidos(DateTime fechaInicio, DateTime fechaFin)
        {
            this.toplistView.Columns.Insert(0, "Cliente", 35 * (int)toplistView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.toplistView.Columns.Insert(1, "Puntos vencidos", 20 * (int)toplistView.Font.SizeInPoints, HorizontalAlignment.Center);
            estadisticasDao.getTop5ClientesPuntosVencidos(fechaInicio, fechaFin,
                result => {
                    result.ForEach(elem => this.toplistView.Items.Add(getItemFromEst(elem)));
                });
        }

        private void prepararTop5ClientesConMayoresCompras(DateTime fechaInicio, DateTime fechaFin) {
            this.toplistView.Columns.Insert(0, "Cliente", 35 * (int)toplistView.Font.SizeInPoints, HorizontalAlignment.Center);
            this.toplistView.Columns.Insert(1, "Cantidad de compras", 20 * (int)toplistView.Font.SizeInPoints, HorizontalAlignment.Center);
            estadisticasDao.getTop5ClientesConCompras(fechaInicio, fechaFin,
                result => {
                    result.ForEach(elem => this.toplistView.Items.Add(getItemFromEst(elem)));
                });
        }


        private ListViewItem getItemFromEst(Estadistico est) {
            ListViewItem item = new ListViewItem();
            item.Text = est.nombre;
            item.SubItems.Add(est.cantidad.ToString());

            item.Tag = est;
            return item;
        }


    }
}
