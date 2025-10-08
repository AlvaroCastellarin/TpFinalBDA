using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rust_Eze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            actualizarGraficos();
        }
        void actualizarGraficos()
        {
            chartEmpresa.Series["Series1"].Points.Clear();
            chartEmpresa.Series["Series1"].Points.AddXY("Enero", 80);
            chartEmpresa.Series["Series1"].Points.AddXY("Febrero", 95);
            chartEmpresa.Series["Series1"].Points.AddXY("Marzo", 60);
            chartEmpresa.Series["Series1"].Points.AddXY("Abril", 75);
            chartEmpresa.Series["Series1"].Points.AddXY("Mayo", 40);
            chartEmpresa.Series["Series1"].Points.AddXY("Junio", 85);
            chartEmpresa.Series["Series1"].Points.AddXY("Julio", 85);
            chartEmpresa.Series["Series1"].Points.AddXY("Agosto", 85);
            chartEmpresa.Series["Series1"].Points.AddXY("Septiembre", 85);
            chartEmpresa.Series["Series1"].Points.AddXY("Octubre", 65);
            chartEmpresa.Series["Series1"].Points.AddXY("Noviembre", 75);
            chartEmpresa.Series["Series1"].Points.AddXY("Diciembre", 55);
            chartEmpresa.ChartAreas[0].AxisX.Interval = 1;
            chartEmpresa.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartEmpresa.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartEmpresa.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chartEmpresa.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            chartSucursales.Series["Series1"].Points.Clear();
            chartSucursales.Series["Series1"].Points.AddXY("Rosario", 90);
            chartSucursales.Series["Series1"].Points.AddXY("Buenos Aires", 100);
            chartSucursales.Series["Series1"].Points.AddXY("Córdoba", 70);
            chartMarcas.Series["Series1"].Points.AddXY("Ford", 40);
            chartMarcas.Series["Series1"].Points.AddXY("Toyota", 35);
            chartMarcas.Series["Series1"].Points.AddXY("Peugeot", 25);
            chartMarcas.Series["Series1"].Points.AddXY("Fiat", 20);
            chartMarcas.Series["Series1"].Points.AddXY("Volkswagen", 30);


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
