namespace Rust_Eze
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dateInicio = new System.Windows.Forms.DateTimePicker();
            this.dateFIn = new System.Windows.Forms.DateTimePicker();
            this.btnAnioPasado = new System.Windows.Forms.Button();
            this.btnEsteanio = new System.Windows.Forms.Button();
            this.btnConfirmarFecha = new System.Windows.Forms.Button();
            this.chartEmpresa = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSucursales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMarcas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSucursales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // dateInicio
            // 
            this.dateInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateInicio.Location = new System.Drawing.Point(17, 7);
            this.dateInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dateInicio.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(136, 22);
            this.dateInicio.TabIndex = 0;
            this.dateInicio.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateFIn
            // 
            this.dateFIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFIn.Location = new System.Drawing.Point(163, 7);
            this.dateFIn.Margin = new System.Windows.Forms.Padding(4);
            this.dateFIn.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateFIn.Name = "dateFIn";
            this.dateFIn.Size = new System.Drawing.Size(136, 22);
            this.dateFIn.TabIndex = 1;
            // 
            // btnAnioPasado
            // 
            this.btnAnioPasado.Location = new System.Drawing.Point(523, 9);
            this.btnAnioPasado.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnioPasado.Name = "btnAnioPasado";
            this.btnAnioPasado.Size = new System.Drawing.Size(140, 28);
            this.btnAnioPasado.TabIndex = 3;
            this.btnAnioPasado.Text = "Año pasado";
            this.btnAnioPasado.UseVisualStyleBackColor = true;
            // 
            // btnEsteanio
            // 
            this.btnEsteanio.Location = new System.Drawing.Point(375, 9);
            this.btnEsteanio.Margin = new System.Windows.Forms.Padding(4);
            this.btnEsteanio.Name = "btnEsteanio";
            this.btnEsteanio.Size = new System.Drawing.Size(140, 28);
            this.btnEsteanio.TabIndex = 5;
            this.btnEsteanio.Text = "Este año";
            this.btnEsteanio.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarFecha
            // 
            this.btnConfirmarFecha.Location = new System.Drawing.Point(308, 9);
            this.btnConfirmarFecha.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirmarFecha.Name = "btnConfirmarFecha";
            this.btnConfirmarFecha.Size = new System.Drawing.Size(59, 28);
            this.btnConfirmarFecha.TabIndex = 7;
            this.btnConfirmarFecha.Text = "Ok";
            this.btnConfirmarFecha.UseVisualStyleBackColor = true;
            // 
            // chartEmpresa
            // 
            chartArea4.Name = "ChartArea1";
            this.chartEmpresa.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartEmpresa.Legends.Add(legend4);
            this.chartEmpresa.Location = new System.Drawing.Point(16, 44);
            this.chartEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.chartEmpresa.Name = "chartEmpresa";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            series4.YValuesPerPoint = 2;
            this.chartEmpresa.Series.Add(series4);
            this.chartEmpresa.Size = new System.Drawing.Size(808, 274);
            this.chartEmpresa.TabIndex = 8;
            title5.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title5.Name = "Total de ventas Rust-Eze";
            title5.Text = "Total de ventas Rust-Eze";
            this.chartEmpresa.Titles.Add(title5);
            // 
            // chartSucursales
            // 
            chartArea5.Name = "ChartArea1";
            this.chartSucursales.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartSucursales.Legends.Add(legend5);
            this.chartSucursales.Location = new System.Drawing.Point(17, 326);
            this.chartSucursales.Margin = new System.Windows.Forms.Padding(4);
            this.chartSucursales.Name = "chartSucursales";
            series5.ChartArea = "ChartArea1";
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartSucursales.Series.Add(series5);
            this.chartSucursales.Size = new System.Drawing.Size(808, 273);
            this.chartSucursales.TabIndex = 9;
            this.chartSucursales.Text = "chart2";
            title6.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title6.Name = "Title1";
            title6.Text = "Ventas por sucursales ";
            this.chartSucursales.Titles.Add(title6);
            // 
            // chartMarcas
            // 
            chartArea6.Name = "ChartArea1";
            this.chartMarcas.ChartAreas.Add(chartArea6);
            legend6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend6.Name = "Legend1";
            this.chartMarcas.Legends.Add(legend6);
            this.chartMarcas.Location = new System.Drawing.Point(832, 44);
            this.chartMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.chartMarcas.Name = "chartMarcas";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartMarcas.Series.Add(series6);
            this.chartMarcas.Size = new System.Drawing.Size(448, 555);
            this.chartMarcas.TabIndex = 10;
            this.chartMarcas.Text = "chart3";
            title7.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title7.Name = "Title1";
            title7.Text = "Ventas por marcas";
            title8.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            title8.Name = "Title2";
            title8.Text = "Elija la sucursal:";
            this.chartMarcas.Titles.Add(title7);
            this.chartMarcas.Titles.Add(title8);
            // 
            // btnHistorico
            // 
            this.btnHistorico.Location = new System.Drawing.Point(671, 9);
            this.btnHistorico.Margin = new System.Windows.Forms.Padding(4);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(140, 28);
            this.btnHistorico.TabIndex = 11;
            this.btnHistorico.Text = "Historico";
            this.btnHistorico.UseVisualStyleBackColor = true;
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Items.AddRange(new object[] {
            "Buenos Aires",
            "Cordoba",
            "Rosario"});
            this.cmbSucursal.Location = new System.Drawing.Point(954, 95);
            this.cmbSucursal.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(160, 24);
            this.cmbSucursal.TabIndex = 12;
            this.cmbSucursal.SelectedIndexChanged += new System.EventHandler(this.cmbSucursal_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 609);
            this.Controls.Add(this.cmbSucursal);
            this.Controls.Add(this.btnHistorico);
            this.Controls.Add(this.chartMarcas);
            this.Controls.Add(this.chartSucursales);
            this.Controls.Add(this.chartEmpresa);
            this.Controls.Add(this.btnConfirmarFecha);
            this.Controls.Add(this.btnEsteanio);
            this.Controls.Add(this.btnAnioPasado);
            this.Controls.Add(this.dateFIn);
            this.Controls.Add(this.dateInicio);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.chartEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSucursales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMarcas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateInicio;
        private System.Windows.Forms.DateTimePicker dateFIn;
        private System.Windows.Forms.Button btnAnioPasado;
        private System.Windows.Forms.Button btnEsteanio;
        private System.Windows.Forms.Button btnConfirmarFecha;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEmpresa;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSucursales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMarcas;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.ComboBox cmbSucursal;
    }
}