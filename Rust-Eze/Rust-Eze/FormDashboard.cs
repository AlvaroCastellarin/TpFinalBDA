using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rust_Eze
{
    public partial class FormDashboard : Form
    {
        RepoEstadisticas repo = new RepoEstadisticas();
        public FormDashboard()
        {
            InitializeComponent();
            chartVentas.Legends[0].Enabled = false;
            chartSucursales.Legends[0].Enabled = false;
        }
        private Dictionary<string, Color> coloresMarcas = new Dictionary<string, Color>
        {
            { "Ford", Color.FromArgb(0, 47, 108) },       // Azul oscuro (Ford)
            { "Toyota", Color.FromArgb(235, 0, 30) },     // Rojo (Toyota)
            { "Peugeot", Color.FromArgb(100, 100, 100) }, // Gris (Peugeot)
            { "Volkswagen", Color.FromArgb(0, 174, 239) },// Azul claro (Volkswagen)
            { "Fiat", Color.FromArgb(170, 0, 0) }         // Rojo oscuro (Fiat)
        };

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
        private int ObtenerObjetivoAnual(string nombreSucursal)
        {

            switch (nombreSucursal)
            {
                case "Rosario":
                    return 420;

                case "Córdoba":
                    return 420;

                case "Buenos Aires":
                    return 480;

                case "Rust-Eze":
                    return 1320;

                default:
                    return 420;
            }
        }
        private int ObtenerObjetivoMensual(string nombreSucursal)
        {

            switch (nombreSucursal)
            {
                case "Rosario":
                    return 35;

                case "Córdoba":
                    return 35;

                case "Buenos Aires":
                    return 40;

                case "Rust-Eze": 
                    return 110;

                default:
                    return 35;
            }
        }
        private void CargarGraficoVentas(int idSucursal, int anioSeleccionado, string nombreSucursal)
        {
            chartVentas.Series.Clear();

            var ventas = repo.ObtenerVentasMensuales(idSucursal, anioSeleccionado);

            var series = chartVentas.Series.Add("Ventas");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            var chartArea = chartVentas.ChartAreas[0];
            int objetivoMensual = ObtenerObjetivoMensual(nombreSucursal);
            chartArea.AxisY.Maximum = objetivoMensual * 1.5; 
            chartArea.AxisY.Title = "Unidades Vendidas";
            chartArea.AxisX.Interval = 1;

            double umbralBajo = objetivoMensual * 0.8;

            foreach (var venta in ventas)
            {
                int puntoIndex = series.Points.AddXY(venta.Mes, venta.Cantidad);
                var punto = series.Points[puntoIndex];

                if (venta.Cantidad > objetivoMensual)
                {
                    punto.Color = Color.FromArgb(40, 167, 69); // Verde
                }
                else if (venta.Cantidad >= umbralBajo)
                {
                    punto.Color = Color.FromArgb(255, 193, 7); // Amarillo
                }
                else
                {
                    punto.Color = Color.FromArgb(220, 53, 69); // Rojo
                }
            }
        }
        

        private void CargarGraficoMarcas(int idSucursal, int anioSeleccionado)
        {
            chartMarcas.Series.Clear();

            var marcas = repo.ObtenerVentasPorMarca(idSucursal, anioSeleccionado);

            var series = chartMarcas.Series.Add("Marcas");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.White;

            int total = marcas.Sum(m => m.Cantidad);

            foreach (var marca in marcas)
            {
                var punto = series.Points.Add(marca.Cantidad);
                if (total > 0)
                    punto.Label = ((double)marca.Cantidad / total * 100).ToString("0") + "%";
                else
                    punto.Label = "0%";
                punto.LegendText = marca.Marca;
                if (coloresMarcas.ContainsKey(marca.Marca))
                    punto.Color = coloresMarcas[marca.Marca];
                else
                    punto.Color = Color.LightGray;
            }
        }

        private void CargarGraficoSucursales(int anioSeleccionado)
        {
            chartSucursales.Series.Clear();
            var ventasPorSucursal = repo.ObtenerVentasPorSucursal(anioSeleccionado);
            var chartArea = chartSucursales.ChartAreas[0];
            chartArea.AxisY.Maximum = 700; 
            chartArea.AxisY.Title = "Unidades Vendidas";
            chartArea.AxisY.LabelStyle.Format = ""; 

            var series = chartSucursales.Series.Add("Sucursales");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series.Label = "#VALY";

            foreach (var item in ventasPorSucursal)
            {
                int objetivoAnual = ObtenerObjetivoAnual(item.Sucursal);
                double umbralBajo = objetivoAnual * 0.8;
                int puntoIndex = series.Points.AddXY(item.Sucursal, item.Total);
                var punto = series.Points[puntoIndex];
                if (item.Total > objetivoAnual)
                {
                    punto.Color = Color.FromArgb(40, 167, 69); // Verde
                }
                else if (item.Total >= umbralBajo)
                {
                    punto.Color = Color.FromArgb(255, 193, 7); // Amarillo
                }
                else
                {
                    punto.Color = Color.FromArgb(220, 53, 69); // Rojo
                }
            }
        }
        private void btnConfirmarFecha_Click(object sender, EventArgs e)
        {
            if (cmbSucursal.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una sucursal.");
                return;
            }

            string sucursalSeleccionada = cmbSucursal.SelectedItem.ToString();
            int anioSeleccionado = dateAnio.Value.Year;

            if (anioSeleccionado < 2020 || anioSeleccionado > DateTime.Now.Year)
            {
                MessageBox.Show("Seleccione un año válido entre 2020 y " + DateTime.Now.Year);
                return;
            }
            int idSucursal = 0; 
            try
            {
                if (sucursalSeleccionada != "Rust-Eze")
                {
                    idSucursal = repo.ObtenerIdSucursal(sucursalSeleccionada);
                }
                labelMarcas.Text = cmbSucursal.SelectedItem.ToString();
                labelVentas.Text = cmbSucursal.SelectedItem.ToString();
                CargarGraficoVentas(idSucursal, anioSeleccionado, sucursalSeleccionada);
                CargarGraficoMarcas(idSucursal, anioSeleccionado);
                CargarGraficoSucursales(anioSeleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnioPasado_Click(object sender, EventArgs e)
        {
            int anioActual = DateTime.Now.Year;

            int anioAnterior = anioActual - 1;

            if (anioAnterior < 2020)
            {
                MessageBox.Show("No hay datos disponibles para años anteriores a 2020.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                dateAnio.Value = new DateTime(anioAnterior, dateAnio.Value.Month, dateAnio.Value.Day);
            }
            catch
            {
                dateAnio.Value = new DateTime(anioAnterior, 1, 1); 
            }
            btnConfirmarFecha_Click(sender, e);
        }
        private void CargarGraficoVentas_Historico(int idSucursal, string nombreSucursal)
        {
            chartVentas.Series.Clear();

            var ventasAnuales = repo.ObtenerVentasAnuales(idSucursal);

            var series = chartVentas.Series.Add("Ventas");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            var chartArea = chartVentas.ChartAreas[0];
            int objetivoAnual = ObtenerObjetivoAnual(nombreSucursal);
            chartArea.AxisY.Maximum = objetivoAnual * 1.5;
            chartArea.AxisY.Title = "Unidades Vendidas";
            chartArea.AxisX.Interval = 0;
            double umbralBajo = objetivoAnual * 0.8;

            foreach (var venta in ventasAnuales)
            {
                int puntoIndex = series.Points.AddXY(venta.Anio, venta.Cantidad);
                var punto = series.Points[puntoIndex];

                if (venta.Cantidad > objetivoAnual)
                {
                    punto.Color = Color.FromArgb(40, 167, 69); // Verde
                }
                else if (venta.Cantidad >= umbralBajo)
                {
                    punto.Color = Color.FromArgb(255, 193, 7); // Amarillo
                }
                else
                {
                    punto.Color = Color.FromArgb(220, 53, 69); // Rojo
                }
            }
        }
        private void CargarGraficoMarcas_Historico(int idSucursal)
        {
            chartMarcas.Series.Clear();

            var marcas = repo.ObtenerVentasPorMarca_Historico(idSucursal);

            var series = chartMarcas.Series.Add("Marcas");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.White;

            int total = marcas.Sum(m => m.Cantidad);
            foreach (var marca in marcas)
            {
                var punto = series.Points.Add(marca.Cantidad);

                if (total > 0)
                    punto.Label = ((double)marca.Cantidad / total * 100).ToString("0") + "%";
                else
                    punto.Label = "0%";
                punto.LegendText = marca.Marca;
                if (coloresMarcas.ContainsKey(marca.Marca))
                    punto.Color = coloresMarcas[marca.Marca];
                else
                    punto.Color = Color.LightGray;
            }
        }
        private void CargarGraficoSucursales_Historico()
        {
            chartSucursales.Series.Clear();
            var ventasPorSucursal = repo.ObtenerVentasPorSucursal_Historico();
            var chartArea = chartSucursales.ChartAreas[0];
            chartArea.AxisY.Maximum = 3500;
            chartArea.AxisY.Title = "Unidades Vendidas (Histórico)";
            chartArea.AxisY.LabelStyle.Format = "";

            var series = chartSucursales.Series.Add("Sucursales");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series.Label = "#VALY";

            // Colores por defecto (Azul, Celeste, Gris)
            Color[] coloresDefault = { Color.FromArgb(0, 99, 177), Color.FromArgb(0, 174, 239), Color.FromArgb(100, 100, 100) };
            int colorIndex = 0;

            foreach (var item in ventasPorSucursal)
            {
                int puntoIndex = series.Points.AddXY(item.Sucursal, item.Total);
                var punto = series.Points[puntoIndex];
                punto.Color = coloresDefault[colorIndex % coloresDefault.Length];
                colorIndex++;
            }
        }
        private void btnHistorico_Click(object sender, EventArgs e)
        {
            if (cmbSucursal.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una sucursal.");
                return;
            }

            string sucursalSeleccionada = cmbSucursal.SelectedItem.ToString();
            int idSucursal = 0;

            try
            {
                if (sucursalSeleccionada != "Rust-Eze")
                    idSucursal = repo.ObtenerIdSucursal(sucursalSeleccionada);
                labelMarcas.Text = cmbSucursal.SelectedItem.ToString();
                labelVentas.Text = cmbSucursal.SelectedItem.ToString();
                CargarGraficoVentas_Historico(idSucursal, sucursalSeleccionada);
                CargarGraficoMarcas_Historico(idSucursal);
                CargarGraficoSucursales_Historico();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al obtener datos históricos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
