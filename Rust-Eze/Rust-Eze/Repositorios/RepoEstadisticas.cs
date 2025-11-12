using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Rust_Eze
{
    public class RepoEstadisticas
    {
        private string CadenaConexion
        {
            get
            {
                try
                {
                    var cs = ConfigurationManager.ConnectionStrings["Concesionario"]?.ConnectionString;
                    if (!string.IsNullOrWhiteSpace(cs)) return cs;
                }
                catch { }
                return @"Data Source=LAPTOP-UQKB2TBV;Initial Catalog=ConcesionarioRustEze;Integrated Security=True;TrustServerCertificate=True;";
            }
        }
      
        public int ObtenerIdSucursal(string nombreCiudad)
        {
            if (nombreCiudad == "Rust-Eze")
                return 0;

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                conn.Open();
                string query = @"
            SELECT s.id_sucursal
            FROM Sucursal s
            JOIN Ciudad c ON s.id_ciudad = c.id_ciudad
            WHERE c.nombre_ciudad = @Ciudad";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Ciudad", nombreCiudad);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        return Convert.ToInt32(result);
                    else
                        throw new Exception($"No se encontró la sucursal para la ciudad '{nombreCiudad}'.");
                }
            }
        }
        public List<(string Mes, int Cantidad)> ObtenerVentasMensuales(int idSucursal, int anio)
        {
            string[] nombresMeses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            var resultados = nombresMeses.Select(m => (Mes: m, Cantidad: 0)).ToList();

            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                conn.Open();
                string query = @"
            SELECT 
                MONTH(fecha_venta) AS Mes, 
                SUM(v.cantidad) AS Cantidad  -- <-- CAMBIO AQUÍ: De COUNT(*) a SUM(v.cantidad)
            FROM Venta v
            WHERE YEAR(fecha_venta) = @Anio
            " + (idSucursal != 0 ? "AND id_sucursal = @Sucursal" : "") + @"
            GROUP BY MONTH(fecha_venta)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Anio", anio);
                    if (idSucursal != 0)
                        cmd.Parameters.AddWithValue("@Sucursal", idSucursal);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            int mesNumero = lector.GetInt32(0);
                            int cantidad = lector.GetInt32(1);
                            resultados[mesNumero - 1] = (Mes: nombresMeses[mesNumero - 1], Cantidad: cantidad);
                        }
                    }
                }
            }
            return resultados;
        }
        public List<(int Anio, int Cantidad)> ObtenerVentasAnuales(int idSucursal)
        {
            int anioActual = DateTime.Now.Year;
            var resultados = new Dictionary<int, int>();
            for (int anio = 2020; anio <= anioActual; anio++)
            {
                resultados[anio] = 0;
            }
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                conn.Open();
                string query = @"
            SELECT 
                YEAR(v.fecha_venta) AS Anio, 
                SUM(v.cantidad) AS Cantidad
            FROM Venta v
            WHERE YEAR(v.fecha_venta) >= 2020
            " + (idSucursal != 0 ? "AND id_sucursal = @Sucursal" : "") + @"
            GROUP BY YEAR(v.fecha_venta)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (idSucursal != 0)
                        cmd.Parameters.AddWithValue("@Sucursal", idSucursal);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            int anioLeido = lector.GetInt32(0);
                            int cantidadLeida = lector.GetInt32(1);

                            if (resultados.ContainsKey(anioLeido))
                            {
                                resultados[anioLeido] = cantidadLeida;
                            }
                        }
                    }
                }
            }
            return resultados.Select(kvp => (Anio: kvp.Key, Cantidad: kvp.Value))
                             .OrderBy(r => r.Anio)
                             .ToList();
        }
        public List<(string Marca, int Cantidad)> ObtenerVentasPorMarca(int idSucursal, int anio)
        {
            List<(string, int)> resultados = new List<(string, int)>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                conn.Open();
                string query = @"
            SELECT 
                ma.nombre_marca, 
                SUM(v.cantidad) AS Cantidad  -- <-- CAMBIO AQUÍ: De COUNT(*) a SUM(v.cantidad)
            FROM Venta v
            JOIN Modelo mo ON v.id_modelo = mo.id_modelo
            JOIN Marca ma ON mo.id_marca = ma.id_marca
            WHERE YEAR(v.fecha_venta) = @Anio
            " + (idSucursal != 0 ? "AND v.id_sucursal = @Sucursal" : "") + @"
            GROUP BY ma.nombre_marca
            ORDER BY Cantidad DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Anio", anio);
                    if (idSucursal != 0)
                        cmd.Parameters.AddWithValue("@Sucursal", idSucursal);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                            resultados.Add((lector.GetString(0), lector.GetInt32(1)));
                    }
                }
            }
            return resultados;
        }
        public List<(string Sucursal, int Total)> ObtenerVentasPorSucursal(int anio)
        {
            List<(string, int)> resultados = new List<(string, int)>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                conn.Open();
                string query = @"
            SELECT 
                ci.nombre_ciudad, 
                SUM(v.cantidad) AS Total
            FROM Venta v
            JOIN Sucursal s ON v.id_sucursal = s.id_sucursal
            JOIN Ciudad ci ON s.id_ciudad = ci.id_ciudad
            WHERE YEAR(v.fecha_venta) = @Anio
            GROUP BY ci.nombre_ciudad
            ORDER BY Total DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Anio", anio);
                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            resultados.Add((lector.GetString(0), lector.GetInt32(1)));
                        }
                    }
                }
            }
            return resultados;
        }
        public List<(string Marca, int Cantidad)> ObtenerVentasPorMarca_Historico(int idSucursal)
        {
            List<(string, int)> resultados = new List<(string, int)>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                conn.Open();
                string query = @"
            SELECT 
                ma.nombre_marca, 
                SUM(v.cantidad) AS Cantidad
            FROM Venta v
            JOIN Modelo mo ON v.id_modelo = mo.id_modelo
            JOIN Marca ma ON mo.id_marca = ma.id_marca
            " + (idSucursal != 0 ? "WHERE v.id_sucursal = @Sucursal" : "") + @"
            GROUP BY ma.nombre_marca
            ORDER BY Cantidad DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (idSucursal != 0)
                        cmd.Parameters.AddWithValue("@Sucursal", idSucursal);

                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                            resultados.Add((lector.GetString(0), lector.GetInt32(1)));
                    }
                }
            }
            return resultados;
        }
        public List<(string Sucursal, int Total)> ObtenerVentasPorSucursal_Historico()
        {
            List<(string, int)> resultados = new List<(string, int)>();
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                conn.Open();
                string query = @"
            SELECT 
                ci.nombre_ciudad, 
                SUM(v.cantidad) AS Total
            FROM Venta v
            JOIN Sucursal s ON v.id_sucursal = s.id_sucursal
            JOIN Ciudad ci ON s.id_ciudad = ci.id_ciudad
            GROUP BY ci.nombre_ciudad
            ORDER BY Total DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            resultados.Add((lector.GetString(0), lector.GetInt32(1)));
                        }
                    }
                }
            }
            return resultados;
        }
    }
}
