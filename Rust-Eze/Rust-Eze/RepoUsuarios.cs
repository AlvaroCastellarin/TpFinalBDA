using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rust_Eze
{
    public class RepoUsuarios
    {
        // Lee la cadena de conexión de App.config; si no existe, usa LocalDB para desarrollo.
        private string CadenaConexion
        {
            get
            {
                try
                {
                    var cs = ConfigurationManager.ConnectionStrings["Concesionario"]?.ConnectionString;
                    if (!string.IsNullOrWhiteSpace(cs)) return cs;
                }
                catch
                {
                    // Ignorar y usar fallback
                }

                // Fallback para desarrollo SIN AttachDbFilename (evita intentar adjuntar archivos que ya están registrados)
                return @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ConcesionarioRustEze;Integrated Security=True;";
            }
        }

        public List<Usuario> getUsuariosList()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT id_usuario, email, password FROM Usuario";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Usuario u = new Usuario();
                            u.Id_usuario = lector.GetInt32(0);
                            u.Email = lector.GetString(1);
                            u.Password = lector.GetString(2);
                            usuarios.Add(u);
                        }
                    }
                    return usuarios;
                }
                catch (Exception ex) { throw new Exception("Error: " + ex.Message); }
            }
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;

            string query = "SELECT id_usuario, email, password FROM Usuario WHERE email = @email";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@email", email);
                try
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            Usuario u = new Usuario();
                            u.Id_usuario = lector.GetInt32(0);
                            u.Email = lector.GetString(1);
                            u.Password = lector.GetString(2);
                            return u;
                        }
                    }
                    return null;
                }
                catch (Exception ex) { throw new Exception("Error: " + ex.Message); }
            }
        }

        public void AddUsuario(string email, string passwordHasheada)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("email vacío");
            if (string.IsNullOrWhiteSpace(passwordHasheada)) throw new ArgumentException("passwordHasheada vacío");

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();

                // Verificar si ya existe el email
                using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(1) FROM Usuario WHERE email = @email", conexion))
                {
                    cmdCheck.Parameters.AddWithValue("@email", email);
                    int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (existe > 0) throw new Exception("El email ya está registrado.");
                }

                // Insertar nuevo usuario
                using (SqlCommand cmdInsert = new SqlCommand("INSERT INTO Usuario (email, password) VALUES (@email, @password)", conexion))
                {
                    cmdInsert.Parameters.AddWithValue("@email", email);
                    cmdInsert.Parameters.AddWithValue("@password", passwordHasheada);
                    cmdInsert.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePassword(string email, string newPasswordHasheada)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("email vacío");
            if (string.IsNullOrWhiteSpace(newPasswordHasheada)) throw new ArgumentException("newPasswordHasheada vacío");

            string query = "UPDATE Usuario SET password = @password WHERE email = @email";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@password", newPasswordHasheada);
                comando.Parameters.AddWithValue("@email", email);
                try
                {
                    conexion.Open();
                    int filas = comando.ExecuteNonQuery();
                    if (filas == 0) throw new Exception("Usuario no encontrado o no se pudo actualizar la contraseña.");
                }
                catch (Exception ex) { throw new Exception("Error: " + ex.Message); }
            }
        }

        // Tokens de recuperación (usa email)
        public string CreateResetToken(string email, TimeSpan validFor)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("email vacío");

            var usuario = GetUsuarioByEmail(email);
            if (usuario == null) throw new Exception("Usuario no encontrado.");

            string token = Guid.NewGuid().ToString("N");
            DateTime expiration = DateTime.UtcNow.Add(validFor);

            string query = "INSERT INTO PasswordResetTokens (email, token, expiration, used) VALUES (@email, @token, @exp, 0)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@token", token);
                comando.Parameters.AddWithValue("@exp", expiration);
                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Error: " + ex.Message); }
            }

            return token;
        }

        public bool ValidateResetToken(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token)) return false;

            string query = "SELECT TOP 1 token, expiration, used FROM PasswordResetTokens WHERE email = @email AND token = @token ORDER BY Id DESC";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@token", token);
                try
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            bool used = lector.GetBoolean(2);
                            DateTime expiration = lector.GetDateTime(1);
                            if (used) return false;
                            if (DateTime.UtcNow > expiration) return false;
                            return true;
                        }
                    }
                    return false;
                }
                catch (Exception ex) { throw new Exception("Error: " + ex.Message); }
            }
        }

        public void MarkTokenUsed(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token)) return;

            string query = "UPDATE PasswordResetTokens SET used = 1 WHERE email = @email AND token = @token";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@token", token);
                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex) { throw new Exception("Error: " + ex.Message); }
            }
        }
    }
}
