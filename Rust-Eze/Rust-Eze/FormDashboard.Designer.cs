namespace Rust_Eze
{
    partial class FormDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title13 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title14 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title15 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dateAnio = new System.Windows.Forms.DateTimePicker();
            this.btnConfirmarFecha = new System.Windows.Forms.Button();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSucursales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMarcas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.btnAnioPasado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelVentas = new System.Windows.Forms.Label();
            this.labelMarcas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSucursales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // dateAnio
            // 
            this.dateAnio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateAnio.CustomFormat = "yyyy";
            this.dateAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateAnio.Location = new System.Drawing.Point(270, 10);
            this.dateAnio.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateAnio.Name = "dateAnio";
            this.dateAnio.ShowUpDown = true;
            this.dateAnio.Size = new System.Drawing.Size(64, 20);
            this.dateAnio.TabIndex = 0;
            this.dateAnio.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnConfirmarFecha
            // 
            this.btnConfirmarFecha.Location = new System.Drawing.Point(340, 7);
            this.btnConfirmarFecha.Name = "btnConfirmarFecha";
            this.btnConfirmarFecha.Size = new System.Drawing.Size(44, 23);
            this.btnConfirmarFecha.TabIndex = 7;
            this.btnConfirmarFecha.Text = "Ok";
            this.btnConfirmarFecha.UseVisualStyleBackColor = true;
            this.btnConfirmarFecha.Click += new System.EventHandler(this.btnConfirmarFecha_Click);
            // 
            // chartVentas
            // 
            chartArea13.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chartVentas.Legends.Add(legend13);
            this.chartVentas.Location = new System.Drawing.Point(12, 36);
            this.chartVentas.Name = "chartVentas";
            series13.ChartArea = "ChartArea1";
            series13.IsVisibleInLegend = false;
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            series13.YValuesPerPoint = 2;
            this.chartVentas.Series.Add(series13);
            this.chartVentas.Size = new System.Drawing.Size(606, 223);
            this.chartVentas.TabIndex = 8;
            title13.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title13.Name = "Total de ventas Rust-Eze";
            title13.Text = "Total de ventas:";
            this.chartVentas.Titles.Add(title13);
            // 
            // chartSucursales
            // 
            chartArea14.Name = "ChartArea1";
            this.chartSucursales.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.chartSucursales.Legends.Add(legend14);
            this.chartSucursales.Location = new System.Drawing.Point(13, 265);
            this.chartSucursales.Name = "chartSucursales";
            series14.ChartArea = "ChartArea1";
            series14.IsVisibleInLegend = false;
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            this.chartSucursales.Series.Add(series14);
            this.chartSucursales.Size = new System.Drawing.Size(606, 222);
            this.chartSucursales.TabIndex = 9;
            this.chartSucursales.Text = "chart2";
            title14.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title14.Name = "Title1";
            title14.Text = "Ventas por sucursales ";
            this.chartSucursales.Titles.Add(title14);
            // 
            // chartMarcas
            // 
            chartArea15.Name = "ChartArea1";
            this.chartMarcas.ChartAreas.Add(chartArea15);
            legend15.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend15.Name = "Legend1";
            this.chartMarcas.Legends.Add(legend15);
            this.chartMarcas.Location = new System.Drawing.Point(624, 36);
            this.chartMarcas.Name = "chartMarcas";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            this.chartMarcas.Series.Add(series15);
            this.chartMarcas.Size = new System.Drawing.Size(336, 451);
            this.chartMarcas.TabIndex = 10;
            this.chartMarcas.Text = "chart3";
            title15.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title15.Name = "Title1";
            title15.Text = "Ventas por marcas:";
            this.chartMarcas.Titles.Add(title15);
            // 
            // btnHistorico
            // 
            this.btnHistorico.Location = new System.Drawing.Point(500, 7);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(105, 23);
            this.btnHistorico.TabIndex = 11;
            this.btnHistorico.Text = "Historico";
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Items.AddRange(new object[] {
            "Buenos Aires",
            "Córdoba",
            "Rosario",
            "Rust-Eze"});
            this.cmbSucursal.Location = new System.Drawing.Point(144, 9);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(121, 21);
            this.cmbSucursal.TabIndex = 12;
            this.cmbSucursal.SelectedIndexChanged += new System.EventHandler(this.cmbSucursal_SelectedIndexChanged);
            // 
            // btnAnioPasado
            // 
            this.btnAnioPasado.Location = new System.Drawing.Point(389, 7);
            this.btnAnioPasado.Name = "btnAnioPasado";
            this.btnAnioPasado.Size = new System.Drawing.Size(105, 23);
            this.btnAnioPasado.TabIndex = 3;
            this.btnAnioPasado.Text = "Año pasado";
            this.btnAnioPasado.UseVisualStyleBackColor = true;
            this.btnAnioPasado.Click += new System.EventHandler(this.btnAnioPasado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Seleccione una sucursal:";
            // 
            // labelVentas
            // 
            this.labelVentas.AutoSize = true;
            this.labelVentas.BackColor = System.Drawing.SystemColors.Window;
            this.labelVentas.Location = new System.Drawing.Point(141, 45);
            this.labelVentas.Name = "labelVentas";
            this.labelVentas.Size = new System.Drawing.Size(123, 13);
            this.labelVentas.TabIndex = 14;
            this.labelVentas.Text = "Seleccione una sucursal";
            // 
            // labelMarcas
            // 
            this.labelMarcas.AutoSize = true;
            this.labelMarcas.BackColor = System.Drawing.SystemColors.Window;
            this.labelMarcas.Location = new System.Drawing.Point(638, 66);
            this.labelMarcas.Name = "labelMarcas";
            this.labelMarcas.Size = new System.Drawing.Size(123, 13);
            this.labelMarcas.TabIndex = 15;
            this.labelMarcas.Text = "Seleccione una sucursal";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 495);
            this.Controls.Add(this.labelMarcas);
            this.Controls.Add(this.labelVentas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSucursal);
            this.Controls.Add(this.btnHistorico);
            this.Controls.Add(this.chartMarcas);
            this.Controls.Add(this.chartSucursales);
            this.Controls.Add(this.chartVentas);
            this.Controls.Add(this.btnConfirmarFecha);
            this.Controls.Add(this.btnAnioPasado);
            this.Controls.Add(this.dateAnio);
            this.Name = "FormDashboard";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSucursales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateAnio;
        private System.Windows.Forms.Button btnConfirmarFecha;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSucursales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMarcas;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private System.Windows.Forms.Button btnAnioPasado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelVentas;
        private System.Windows.Forms.Label labelMarcas;
    }
}