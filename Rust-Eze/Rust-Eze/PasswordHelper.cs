using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rust_Eze
{
    public static class PasswordHelper
    {
        // Número de iteraciones; se puede aumentar en el futuro si hace falta
        private const int Iterations = 10000;

        public static string HashPassword(string password)
        {
            // Genera salt de 16 bytes
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Genera hash de 20 bytes usando PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] hash = pbkdf2.GetBytes(20);

                // Almacena salt+hash en un array de 36 bytes
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);

                // Devuelve en Base64 para guardar en DB
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(storedHash)) return false;

            byte[] hashBytes;
            try
            {
                hashBytes = Convert.FromBase64String(storedHash);
            }
            catch
            {
                return false;
            }

            if (hashBytes.Length != 36) return false;

            // Extrae salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Recalcula hash con la misma salt e iteraciones
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] hash = pbkdf2.GetBytes(20);

                // Compara
                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                        return false;
            }
            return true;
        }
    }
}
