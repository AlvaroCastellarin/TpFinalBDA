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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem1 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem2 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem3 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem4 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem5 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.dateInicio.Location = new System.Drawing.Point(13, 6);
            this.dateInicio.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(103, 20);
            this.dateInicio.TabIndex = 0;
            this.dateInicio.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateFIn
            // 
            this.dateFIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFIn.Location = new System.Drawing.Point(122, 6);
            this.dateFIn.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateFIn.Name = "dateFIn";
            this.dateFIn.Size = new System.Drawing.Size(103, 20);
            this.dateFIn.TabIndex = 1;
            // 
            // btnAnioPasado
            // 
            this.btnAnioPasado.Location = new System.Drawing.Point(392, 7);
            this.btnAnioPasado.Name = "btnAnioPasado";
            this.btnAnioPasado.Size = new System.Drawing.Size(105, 23);
            this.btnAnioPasado.TabIndex = 3;
            this.btnAnioPasado.Text = "Año pasado";
            this.btnAnioPasado.UseVisualStyleBackColor = true;
            // 
            // btnEsteanio
            // 
            this.btnEsteanio.Location = new System.Drawing.Point(281, 7);
            this.btnEsteanio.Name = "btnEsteanio";
            this.btnEsteanio.Size = new System.Drawing.Size(105, 23);
            this.btnEsteanio.TabIndex = 5;
            this.btnEsteanio.Text = "Este año";
            this.btnEsteanio.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarFecha
            // 
            this.btnConfirmarFecha.Location = new System.Drawing.Point(231, 7);
            this.btnConfirmarFecha.Name = "btnConfirmarFecha";
            this.btnConfirmarFecha.Size = new System.Drawing.Size(44, 23);
            this.btnConfirmarFecha.TabIndex = 7;
            this.btnConfirmarFecha.Text = "Ok";
            this.btnConfirmarFecha.UseVisualStyleBackColor = true;
            // 
            // chartEmpresa
            // 
            chartArea1.Name = "ChartArea1";
            this.chartEmpresa.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartEmpresa.Legends.Add(legend1);
            this.chartEmpresa.Location = new System.Drawing.Point(12, 36);
            this.chartEmpresa.Name = "chartEmpresa";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chartEmpresa.Series.Add(series1);
            this.chartEmpresa.Size = new System.Drawing.Size(606, 223);
            this.chartEmpresa.TabIndex = 8;
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Total de ventas Rust-Eze";
            title1.Text = "Total de ventas Rust-Eze";
            this.chartEmpresa.Titles.Add(title1);
            // 
            // chartSucursales
            // 
            chartArea2.Name = "ChartArea1";
            this.chartSucursales.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSucursales.Legends.Add(legend2);
            this.chartSucursales.Location = new System.Drawing.Point(13, 265);
            this.chartSucursales.Name = "chartSucursales";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSucursales.Series.Add(series2);
            this.chartSucursales.Size = new System.Drawing.Size(606, 222);
            this.chartSucursales.TabIndex = 9;
            this.chartSucursales.Text = "chart2";
            title2.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Ventas por sucursales ";
            this.chartSucursales.Titles.Add(title2);
            // 
            // chartMarcas
            // 
            chartArea3.Name = "ChartArea1";
            this.chartMarcas.ChartAreas.Add(chartArea3);
            legendItem1.BackImageTransparentColor = System.Drawing.Color.Red;
            legendItem1.BackSecondaryColor = System.Drawing.Color.Red;
            legendItem1.Color = System.Drawing.Color.Red;
            legendItem1.Name = "Toyota";
            legendItem2.Color = System.Drawing.Color.DodgerBlue;
            legendItem2.Name = "Volkswagen";
            legendItem3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            legendItem3.Name = "Ford";
            legendItem4.Color = System.Drawing.Color.Silver;
            legendItem4.Name = "Peugeot";
            legendItem5.Color = System.Drawing.Color.Green;
            legendItem5.Name = "Fiat";
            legend3.CustomItems.Add(legendItem1);
            legend3.CustomItems.Add(legendItem2);
            legend3.CustomItems.Add(legendItem3);
            legend3.CustomItems.Add(legendItem4);
            legend3.CustomItems.Add(legendItem5);
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend3.Name = "Legend1";
            this.chartMarcas.Legends.Add(legend3);
            this.chartMarcas.Location = new System.Drawing.Point(624, 36);
            this.chartMarcas.Name = "chartMarcas";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartMarcas.Series.Add(series3);
            this.chartMarcas.Size = new System.Drawing.Size(336, 451);
            this.chartMarcas.TabIndex = 10;
            this.chartMarcas.Text = "chart3";
            title3.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "Ventas por marcas";
            title4.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            title4.Name = "Title2";
            title4.Text = "Elija la sucursal:";
            this.chartMarcas.Titles.Add(title3);
            this.chartMarcas.Titles.Add(title4);
            // 
            // btnHistorico
            // 
            this.btnHistorico.Location = new System.Drawing.Point(503, 7);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(105, 23);
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
            this.cmbSucursal.Location = new System.Drawing.Point(738, 82);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(121, 21);
            this.cmbSucursal.TabIndex = 12;
            this.cmbSucursal.SelectedIndexChanged += new System.EventHandler(this.cmbSucursal_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 495);
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