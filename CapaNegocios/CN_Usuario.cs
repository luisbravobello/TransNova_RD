using Microsoft.Data.SqlClient;
using CapaDatos;
using System;

namespace CapaNegocios
{
    public class CD_Usuario
    {
        private readonly Conexion conexion; // La conexión se instancia aquí

        // Constructor
        public CD_Usuario()
        {
            conexion = new Conexion();  // Instanciamos la clase de conexión
        }

        // Método que verifica si un usuario con la clave y contraseña especificadas existe en la base de datos
        public bool VerificarLogin(string clave, string contraseña)
        {
            try
            {
                conexion.Abrir();  // Abrimos la conexión

                // Procedimiento SQL para verificar las credenciales del usuario
                string query = "SELECT COUNT(1) FROM Usuarios WHERE Clave = @Clave AND Contraseña = @Contraseña";
                SqlCommand cmd = new SqlCommand(query, conexion.ObtenerConexion());
                cmd.Parameters.AddWithValue("@Clave", clave);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                // Ejecutamos el comando y obtenemos el resultado
                int count = Convert.ToInt32(cmd.ExecuteScalar()); // Si count > 0, el usuario existe

                return count > 0; // Si el usuario existe, return true
            }
            catch (Exception ex)
            {
                // Capturamos y lanzamos la excepción si ocurre un error
                throw new Exception("Error al verificar las credenciales del usuario.", ex);
            }
            finally
            {
                conexion.Cerrar();  // Cerramos la conexión siempre
            }
        }
    }
}
