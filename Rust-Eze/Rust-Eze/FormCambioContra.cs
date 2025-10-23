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
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblActual;
        private TextBox txtActual;
        private Label lblNueva;
        private TextBox txtNueva;
        private Label lblConfirmar;
        private TextBox txtConfirmar;
        private Button btnCambiar;
        private Button btnCancelar;

        private readonly bool isRecoveryMode;

        // recoveryMode = true -> formulario para restablecer con token (no pide contraseña actual)
        public FormCambioContra(string usuarioInicial = null, bool recoveryMode = false)
        {
            isRecoveryMode = recoveryMode;
            InitializeCustomComponent();
            if (!string.IsNullOrWhiteSpace(usuarioInicial))
                txtUsuario.Text = usuarioInicial;

            if (isRecoveryMode)
            {
                // Ajustes UI para recuperación por token
                lblUsuario.Text = "Email";
                lblActual.Text = "Código (token)";
                txtActual.UseSystemPasswordChar = false;
                lblActual.Visible = true;
                txtActual.Visible = true;
            }
            else
            {
                lblUsuario.Text = "Usuario";
                lblActual.Text = "Contraseña actual";
                txtActual.UseSystemPasswordChar = true;
            }
        }

        private void InitializeCustomComponent()
        {
            this.Text = "Cambiar contraseña";
            this.Size = new Size(380, 260);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            lblUsuario = new Label() { Left = 20, Top = 20, Text = "Usuario", AutoSize = true };
            txtUsuario = new TextBox() { Left = 140, Top = 18, Width = 200 };

            lblActual = new Label() { Left = 20, Top = 58, Text = "Contraseña actual", AutoSize = true };
            txtActual = new TextBox() { Left = 140, Top = 56, Width = 200, UseSystemPasswordChar = true };

            lblNueva = new Label() { Left = 20, Top = 96, Text = "Nueva contraseña", AutoSize = true };
            txtNueva = new TextBox() { Left = 140, Top = 94, Width = 200, UseSystemPasswordChar = true };

            lblConfirmar = new Label() { Left = 20, Top = 134, Text = "Confirmar nueva", AutoSize = true };
            txtConfirmar = new TextBox() { Left = 140, Top = 132, Width = 200, UseSystemPasswordChar = true };

            btnCambiar = new Button() { Text = "Cambiar", Left = 140, Width = 90, Top = 175 };
            btnCambiar.Click += BtnCambiar_Click;

            btnCancelar = new Button() { Text = "Cancelar", Left = 250, Width = 90, Top = 175, DialogResult = DialogResult.Cancel };
            btnCancelar.Click += (s, e) => this.Close();

            this.Controls.Add(lblUsuario);
            this.Controls.Add(txtUsuario);
            this.Controls.Add(lblActual);
            this.Controls.Add(txtActual);
            this.Controls.Add(lblNueva);
            this.Controls.Add(txtNueva);
            this.Controls.Add(lblConfirmar);
            this.Controls.Add(txtConfirmar);
            this.Controls.Add(btnCambiar);
            this.Controls.Add(btnCancelar);
        }

        private void BtnCambiar_Click(object sender, EventArgs e)
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
                    // Modo normal: validar contraseña actual
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
                    // Modo recuperación: actualOrToken contiene el token enviado por email
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
