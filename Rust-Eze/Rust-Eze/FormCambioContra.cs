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
    public partial class FormCambioContra : Form
    {
        private readonly bool isRecoveryMode;

        public FormCambioContra(string usuarioInicial = null, bool recoveryMode = false)
        {
            isRecoveryMode = recoveryMode;
            InitializeComponent();

            if (!string.IsNullOrWhiteSpace(usuarioInicial))
                txtUsuario.Text = usuarioInicial;

            if (isRecoveryMode)
            {
                this.Text = "Recuperar Contraseña";
                lblUsuario.Text = "Email";
                lblActual.Text = "Código (token)";
                txtActual.UseSystemPasswordChar = false;

                
                txtActual.Enabled = false;
                txtNueva.Enabled = false;
                txtConfirmar.Enabled = false;
                btnCambiar.Enabled = false;
            }
            else
            {
                this.Text = "Cambiar Contraseña";
                lblUsuario.Text = "Usuario";
                lblActual.Text = "Contraseña actual";
                txtActual.UseSystemPasswordChar = true;
                btnEnviarCodigo.Visible = false;
            }
        }


        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            string email = txtUsuario.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Debe ingresar el E-mail para enviar el código de recuperación.", "E-mail Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                RepoUsuarios repo = new RepoUsuarios();
                var usuarioObj = repo.GetUsuarioByEmail(email);

                if (usuarioObj == null)
                {
                    MessageBox.Show("Si el email ingresado está registrado, recibirá un correo. Revise su bandeja.",
                                    "Proceso Iniciado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string token = repo.CreateResetToken(email, TimeSpan.FromHours(1));

                try
                {
                    EmailHelper.SendResetEmail(usuarioObj.Email, usuarioObj.Email, token);
                    MessageBox.Show("Se envió un correo con el código de recuperación. Ya puede ingresarlo y elegir una nueva contraseña.", "Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exSend)
                {
                    MessageBox.Show("No se pudo enviar el correo: " + exSend.Message + "\n\nToken (solo pruebas): " + token,
                                    "Error envío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

 
                txtActual.Enabled = true;
                btnCambiar.Enabled = true;
                txtNueva.Enabled = true;
                txtConfirmar.Enabled = true;

                btnCambiar.Enabled = true;
                btnEnviarCodigo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al solicitar el código: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string actualOrToken = txtActual.Text;
            string nueva = txtNueva.Text;
            string confirmar = txtConfirmar.Text;

            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(nueva) || string.IsNullOrWhiteSpace(confirmar) ||
                string.IsNullOrWhiteSpace(actualOrToken))
            {
                MessageBox.Show("Complete todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nueva != confirmar)
            {
                MessageBox.Show("La nueva contraseña y la confirmación no coinciden.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                RepoUsuarios repo = new RepoUsuarios();

                if (!isRecoveryMode)
                {
                    // Lógica para cambiar contraseña conociendo la actual
                    var usuarioObj = repo.GetUsuarioByEmail(usuario);
                    if (usuarioObj == null)
                    {
                        MessageBox.Show("Usuario no encontrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool actualCorrecta = PasswordHelper.VerifyPassword(actualOrToken, usuarioObj.Password);
                    if (!actualCorrecta)
                    {
                        MessageBox.Show("La contraseña actual es incorrecta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string nuevaHasheada = PasswordHelper.HashPassword(nueva);
                    repo.UpdatePassword(usuarioObj.Email, nuevaHasheada);

                    MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Lógica para restablecer contraseña con el Token
                    var usuarioObj = repo.GetUsuarioByEmail(usuario);
                    if (usuarioObj == null)
                    {
                        MessageBox.Show("Usuario no encontrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool tokenValido = repo.ValidateResetToken(usuario, actualOrToken);
                    if (!tokenValido)
                    {
                        MessageBox.Show("Token inválido o expirado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string nuevaHasheada = PasswordHelper.HashPassword(nueva);
                    repo.UpdatePassword(usuarioObj.Email, nuevaHasheada);
                    repo.MarkTokenUsed(usuarioObj.Email, actualOrToken);

                    MessageBox.Show("Contraseña restablecida correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
