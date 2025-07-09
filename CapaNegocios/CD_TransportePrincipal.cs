using Microsoft.Data.SqlClient;
using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CD_Transporte
    {
        private readonly Conexion conexion;

        public CD_Transporte()
        {
            conexion = new Conexion(); // Instanciamos la clase de conexión
        }

        // Mostrar todos los transportes desde la base de datos
        public DataTable MostrarTransportes()
        {
            DataTable tabla = new DataTable();
            try
            {
                conexion.Abrir();  // Abrimos la conexión

                // Comando SQL para obtener todos los transportes
                string query = "SELECT * FROM Transportes";
                SqlCommand cmd = new SqlCommand(query, conexion.ObtenerConexion());

                // Usamos un DataAdapter para llenar un DataTable con los resultados
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla); // Llenamos el DataTable con los datos

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los transportes desde la base de datos.", ex);
            }
            finally
            {
                conexion.Cerrar();  // Cerramos la conexión siempre
            }
        }

        public DataTable MostrarTransportesPorTipo(string tipo)
        {
            try
            {
                // Consulta SQL para filtrar los transportes por tipo
                string query = "SELECT * FROM Transportes WHERE Tipo = @Tipo";
                SqlCommand cmd = new SqlCommand(query, conexion.ObtenerConexion());
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los transportes por tipo", ex);
            }
        }

        public DataTable ObtenerTransportePorId(int id)
        {
            try
            {
                conexion.Abrir(); // Aseguramos abrir la conexión antes del uso

                using (SqlCommand cmd = new SqlCommand("ObtenerTransportePorId", conexion.ObtenerConexion()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el transporte por ID", ex);
            }
            finally
            {
                conexion.Cerrar(); // Siempre cerramos la conexión
            }
        }

        // Insertar nuevo transporte
        public void InsertarTransporte(string tipo, string placa, string conductor, int capacidad, string ruta, string inicio, string destino, TimeSpan hora, decimal tarifa, string? linea, int? estaciones, int? vagones)
        {
            try
            {
                conexion.Abrir();  // Abrir la conexión  

                // Comando SQL para insertar un nuevo transporte
                string query = @"
                    INSERT INTO Transportes (Tipo, Placa, Conductor, Capacidad, Ruta, LugarInicio, DestinoFin, HoraInicio, Tarifa, Linea, Estaciones, Vagones) 
                    VALUES (@Tipo, @Placa, @Conductor, @Capacidad, @Ruta, @LugarInicio, @DestinoFin, @HoraInicio, @Tarifa, @Linea, @Estaciones, @Vagones)";

                SqlCommand cmd = new SqlCommand(query, conexion.ObtenerConexion());
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@Placa", (object?)placa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Conductor", (object?)conductor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Capacidad", capacidad);
                cmd.Parameters.AddWithValue("@Ruta", ruta);
                cmd.Parameters.AddWithValue("@LugarInicio", inicio);
                cmd.Parameters.AddWithValue("@DestinoFin", destino);
                cmd.Parameters.AddWithValue("@HoraInicio", hora);
                cmd.Parameters.AddWithValue("@Tarifa", tarifa);
                cmd.Parameters.AddWithValue("@Linea", (object?)linea ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estaciones", (object?)estaciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Vagones", (object?)vagones ?? DBNull.Value);

                // Ejecutamos el comando para insertar los datos
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el transporte en la base de datos.", ex);
            }
            finally
            {
                conexion.Cerrar();  // Cerramos la conexión siempre
            }
        }

        // Editar transporte
        public void EditarTransporte(int id, string tipo, string placa, string conductor, int capacidad, string ruta, string inicio, string destino, TimeSpan hora, decimal tarifa, string? linea, int? estaciones, int? vagones)
        {
            try
            {
                conexion.Abrir();  // Abrir la conexión  

                // Comando SQL para actualizar un transporte
                string query = @"
                    UPDATE Transportes
                    SET Tipo = @Tipo, Placa = @Placa, Conductor = @Conductor, Capacidad = @Capacidad, Ruta = @Ruta, LugarInicio = @LugarInicio, DestinoFin = @DestinoFin, HoraInicio = @HoraInicio, Tarifa = @Tarifa, Linea = @Linea, Estaciones = @Estaciones, Vagones = @Vagones
                    WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conexion.ObtenerConexion());
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@Placa", (object?)placa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Conductor", (object?)conductor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Capacidad", capacidad);
                cmd.Parameters.AddWithValue("@Ruta", ruta);
                cmd.Parameters.AddWithValue("@LugarInicio", inicio);
                cmd.Parameters.AddWithValue("@DestinoFin", destino);
                cmd.Parameters.AddWithValue("@HoraInicio", hora);
                cmd.Parameters.AddWithValue("@Tarifa", tarifa);
                cmd.Parameters.AddWithValue("@Linea", (object?)linea ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estaciones", (object?)estaciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Vagones", (object?)vagones ?? DBNull.Value);

                // Ejecutamos el comando para actualizar los datos
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el transporte en la base de datos.", ex);
            }
            finally
            {
                conexion.Cerrar();  // Cerramos la conexión siempre
            }
        }

        // Eliminar transporte
        public void EliminarTransporte(int id)
        {
            try
            {
                conexion.Abrir();  // Abrir la conexión  

                // Comando SQL para eliminar un transporte
                string query = "DELETE FROM Transportes WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conexion.ObtenerConexion());
                cmd.Parameters.AddWithValue("@Id", id);

                // Ejecutamos el comando para eliminar el transporte
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el transporte de la base de datos.", ex);
            }
            finally
            {
                conexion.Cerrar();  // Cerramos la conexión siempre
            }
        }
    }
}
