using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rust_Eze
{
    public partial class FormInicio : Form
    {
        RepoUsuarios ru = new RepoUsuarios();
        public FormInicio()
        {
            InitializeComponent();
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = !chkMostrar.Checked;
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
        }

        // Valida inicio de sesión usando email + contraseña hasheada
        bool ValidarLogin()
        {
            string email = txtEmail.Text.Trim(); 
            if (string.IsNullOrWhiteSpace(email)) return false;

            var usuario = ru.GetUsuarioByEmail(email);
            if (usuario == null) return false;

            return PasswordHelper.VerifyPassword(txtContrasenia.Text, usuario.Password);
        }

        private int intentos = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtContrasenia.Text))
                {
                    MessageBox.Show("Debe completar ambos campos (email y contraseña).");
                    return;
                }
                if (ValidarLogin())
                {
                    FormDashboard form1 = new FormDashboard();
                    this.Hide();
                    form1.FormClosed += (s, args) => this.Close(); // cierra login cuando se cierra el dashboard
                    form1.Show();
                    return;
                }

                intentos--;
                if (intentos > 0)
                {
                    MessageBox.Show($"Email o contraseña incorrectos. Quedan {intentos} intentos.");
                }
                else
                {
                    MessageBox.Show("Has superado el número máximo de intentos. La aplicación se cerrará.");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCambiarContra_Click(object sender, EventArgs e)
        {
            string emailPrefill = txtEmail.Text.Trim();

            string emailParaFormulario = string.IsNullOrWhiteSpace(emailPrefill) ? null : emailPrefill;


            using (var frm = new FormCambioContra(emailParaFormulario, true))
            {
                var res = frm.ShowDialog(this);

                if (res == DialogResult.OK)
                {
                    MessageBox.Show("Contraseña cambiada correctamente.", "Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            using (var frm = new FormRegistro())
            {
                var res = frm.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    MessageBox.Show("Registro exitoso. Ya puedes iniciar sesión con el email y la contraseña.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

