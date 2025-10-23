using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rust_Eze
{
    public class Usuario
    {
        private int id_usuario;
        private string email;
        private string password;

        public int Id_usuario { get { return id_usuario; } set { id_usuario = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
    }
}
