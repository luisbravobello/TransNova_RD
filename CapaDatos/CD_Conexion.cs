using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace CapaDatos
{
    public class Conexion
    {
        private SqlConnection conexion;

        public Conexion()
        {
            // Asegúrate de que esta cadena de conexión sea la correcta para tu base de datos.
            string cadenaConexion = "Server=. ;Database=Transporte;Integrated Security=True;TrustServerCertificate=True;";


            conexion = new SqlConnection(cadenaConexion);
        }

        // Método para abrir la conexión
        public void Abrir()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }

        // Método para cerrar la conexión
        public void Cerrar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

        // Obtener la conexión (para usarla en otras clases)
        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }
    }
}
