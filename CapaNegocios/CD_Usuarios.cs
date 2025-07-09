using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        private string connectionString = "Server=.;Database=Transporte;Integrated Security=True;TrustServerCertificate=True;";

        // Método para insertar un nuevo usuario
        public void InsertarUsuario(string usuario, string contraseña)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (Clave, Contraseña) VALUES (@Clave, @Contraseña)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Clave", usuario);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el usuario: " + ex.Message);
            }
        }

        // Método para obtener todos los usuarios
        public DataTable ObtenerUsuarios()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios", conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios: " + ex.Message);
            }
        }

        // Método para eliminar un usuario
        public void EliminarUsuario(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Usuarios WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: " + ex.Message);
            }
        }
    }
}
