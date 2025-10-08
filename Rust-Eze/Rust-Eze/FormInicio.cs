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
        RepoUsuarios ru= new RepoUsuarios();
        public FormInicio()
        {
            InitializeComponent();
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked == true) txtContrasenia.UseSystemPasswordChar = false;
            else txtContrasenia.UseSystemPasswordChar = true;
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
        }
        bool ValidarLogin()
        {
            List<Usuario> u = ru.getUsuariosList();
            return u.Any(x => x.Nombre_usuario == txtUsuario.Text && x.Password == txtContrasenia.Text);
        }
        private int intentos = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasenia.Text))
                {
                    MessageBox.Show("Debe completar ambos campos.");
                    return;
                }
                if (ValidarLogin())
                {
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                    form1.FormClosed += (s, args) => this.Close(); // cierra login cuando se cierra el dashboard
                    form1.Show();
                    return;
                }

                intentos--;
                if (intentos > 0)
                {
                    MessageBox.Show($"Usuario o contraseña incorrectos. Quedan {intentos} intentos.");
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
    }
}

