using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rust_Eze
{
    public class RepoUsuarios
    {
        private string cadenaConexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=ConcesionarioRustEze;Integrated Security=True;TrustServerCertificate=True;";
        public List<Usuario> getUsuariosList()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT * FROM Usuario";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        Usuario u = new Usuario();
                        u.Id_usuario = lector.GetInt32(0);
                        u.Nombre_usuario = lector.GetString(1);
                        u.Password = lector.GetString(2);
                        usuarios.Add(u);
                    }
                    lector.Close();
                    conexion.Close();
                    return usuarios;
                }
                catch (Exception ex) { throw new Exception("Error: " + ex.Message); }
            }
        }
    }
}
