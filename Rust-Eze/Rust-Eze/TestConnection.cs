using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Rust_Eze
{
    public static class TestConnection
    {
        public static string Probar(string cadena)
        {
            try
            {
                using (var c = new SqlConnection(cadena))
                {
                    c.Open();
                    return "OK - Conexión abierta";
                }
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

        public static string ProbarDesdeConfig()
        {
            var cs = ConfigurationManager.ConnectionStrings["Concesionario"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(cs)) return "No existe connectionStrings[\"Concesionario\"] en App.config";
            return Probar(cs);
        }
    }
}
