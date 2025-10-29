using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Rust_Eze
{
    public class FormRegistro : Form
    {
        private TextBox txtEmail;
        private TextBox txtClave;
        private TextBox txtConfirmar;
        private Button btnRegistrar;
        private Button btnCancelar;
        private Label lblEmail;
        private Label lblClave;
        private Label lblConfirmar;

        public FormRegistro()
        {
            InitializeComponent();
            btnRegistrar.Click += BtnRegistrar_Click;
            btnCancelar.Click += (s, e) => this.Close();
        }

        private void InitializeComponent()
        {
            this.Text = "Registro de usuario";
            this.Size = new Size(360, 230);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            lblEmail = new Label() { Left = 20, Top = 20, Text = "Email", AutoSize = true };
            txtEmail = new TextBox() { Left = 120, Top = 18, Width = 200 };

            lblClave = new Label() { Left = 20, Top = 58, Text = "Contraseña", AutoSize = true };
            txtClave = new TextBox() { Left = 120, Top = 56, Width = 200, UseSystemPasswordChar = true };

            lblConfirmar = new Label() { Left = 20, Top = 96, Text = "Confirmar", AutoSize = true };
            txtConfirmar = new TextBox() { Left = 120, Top = 94, Width = 200, UseSystemPasswordChar = true };

            btnRegistrar = new Button() { Text = "Registrar", Left = 120, Width = 90, Top = 140, DialogResult = DialogResult.None };


            btnCancelar = new Button() { Text = "Cancelar", Left = 230, Width = 90, Top = 140, DialogResult = DialogResult.Cancel };

            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblClave);
            this.Controls.Add(txtClave);
            this.Controls.Add(lblConfirmar);
            this.Controls.Add(txtConfirmar);
            this.Controls.Add(btnRegistrar);
            this.Controls.Add(btnCancelar);
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string clave = txtClave.Text;
            string confirmar = txtConfirmar.Text;

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Ingrese un email válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Complete la contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (clave != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string claveHasheada = PasswordHelper.HashPassword(clave);
                RepoUsuarios repo = new RepoUsuarios();
                repo.AddUsuario(email, claveHasheada);

                MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error en la base de datos: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}