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
            string email = txtEmail.Text.Trim(); // requiere que en el Designer el textbox se llame txtEmail
            if (string.IsNullOrWhiteSpace(email)) return false;

            var usuario = ru.GetUsuarioByEmail(email);
            if (usuario == null) return false;

            return PasswordHelper.VerifyPassword(txtContrasenia.Text, usuario.Password);
        }

        private int intentos = 3;
        // Botón para iniciar sesión
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
            // Requiere que en el login el campo de email se llame txtEmail
            string emailPrefill = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(emailPrefill))
            {
                MessageBox.Show("Ingrese su email en el campo antes de solicitar recuperación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                RepoUsuarios repo = new RepoUsuarios();
                var usuarioObj = repo.GetUsuarioByEmail(emailPrefill);
                if (usuarioObj == null)
                {
                    MessageBox.Show("Email no registrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear token (válido 1 hora)
                string token = repo.CreateResetToken(emailPrefill, TimeSpan.FromHours(1));

                // Enviar mail (puede lanzar excepción si SMTP mal configurado)
                try
                {
                    EmailHelper.SendResetEmail(usuarioObj.Email, usuarioObj.Email, token);
                    MessageBox.Show("Se envió un correo con el código de recuperación. Revisa tu bandeja.", "Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exSend)
                {
                    // Mostrar error completo y el token para pruebas locales
                    MessageBox.Show("No se pudo enviar el correo: " + exSend.Message + "\n\nToken (solo pruebas): " + token,
                                    "Error envío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Abrir formulario en modo recuperación (pedirá token + nueva contraseña)
                using (var frm = new FormCambioContra(emailPrefill, true))
                {
                    var res = frm.ShowDialog(this);
                    if (res == DialogResult.OK)
                    {
                        MessageBox.Show("Contraseña cambiada correctamente.", "Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

