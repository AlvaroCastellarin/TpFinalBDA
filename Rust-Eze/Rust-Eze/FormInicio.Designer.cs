namespace Rust_Eze
{
    partial class FormInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.chkMostrar = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegistro = new System.Windows.Forms.Label();
            this.btnCambiarContra = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña: ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(16, 50);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(176, 22);
            this.txtEmail.TabIndex = 2;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Location = new System.Drawing.Point(15, 102);
            this.txtContrasenia.Margin = new System.Windows.Forms.Padding(4);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(177, 22);
            this.txtContrasenia.TabIndex = 3;
            this.txtContrasenia.UseSystemPasswordChar = true;
            this.txtContrasenia.TextChanged += new System.EventHandler(this.txtContrasenia_TextChanged);
            // 
            // chkMostrar
            // 
            this.chkMostrar.AutoSize = true;
            this.chkMostrar.Location = new System.Drawing.Point(200, 104);
            this.chkMostrar.Margin = new System.Windows.Forms.Padding(4);
            this.chkMostrar.Name = "chkMostrar";
            this.chkMostrar.Size = new System.Drawing.Size(74, 20);
            this.chkMostrar.TabIndex = 4;
            this.chkMostrar.Text = "Mostrar";
            this.chkMostrar.UseVisualStyleBackColor = true;
            this.chkMostrar.CheckedChanged += new System.EventHandler(this.chkMostrar_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 166);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Iniciar Sesion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 213);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "¿No tenes una cuenta?";
            // 
            // btnRegistro
            // 
            this.btnRegistro.AutoSize = true;
            this.btnRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRegistro.Location = new System.Drawing.Point(166, 213);
            this.btnRegistro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(69, 16);
            this.btnRegistro.TabIndex = 0;
            this.btnRegistro.Text = "Registrate";
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // btnCambiarContra
            // 
            this.btnCambiarContra.AutoSize = true;
            this.btnCambiarContra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarContra.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnCambiarContra.Location = new System.Drawing.Point(13, 131);
            this.btnCambiarContra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnCambiarContra.Name = "btnCambiarContra";
            this.btnCambiarContra.Size = new System.Drawing.Size(162, 16);
            this.btnCambiarContra.TabIndex = 6;
            this.btnCambiarContra.Text = "¿Olvidaste la contraseña?";
            this.btnCambiarContra.Click += new System.EventHandler(this.btnCambiarContra_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(291, 256);
            this.Controls.Add(this.btnCambiarContra);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkMostrar);
            this.Controls.Add(this.txtContrasenia);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRegistro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de sesion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.CheckBox chkMostrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label btnRegistro;
        private System.Windows.Forms.Label btnCambiarContra;
    }
}

