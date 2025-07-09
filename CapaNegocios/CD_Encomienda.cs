using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace CapaDatos
{
    public class CD_Encomienda
    {
        private readonly string connectionString = "Server=. ;Database=Transporte;Integrated Security=True;TrustServerCertificate=True;";

        // Método para insertar una encomienda
        public void InsertarEncomienda(string codigoSeguimiento, string tipoTransporte, string placa, string remitente,
                                       string destinatario, string direccionEntrega, decimal peso, DateTime fechaEstimadaEntrega,
                                       string estado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertarEncomienda", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CodigoSeguimiento", codigoSeguimiento);
                        cmd.Parameters.AddWithValue("@TipoTransporte", tipoTransporte);
                        cmd.Parameters.AddWithValue("@Placa", placa);
                        cmd.Parameters.AddWithValue("@Remitente", remitente);
                        cmd.Parameters.AddWithValue("@Destinatario", destinatario);
                        cmd.Parameters.AddWithValue("@DireccionEntrega", direccionEntrega);
                        cmd.Parameters.AddWithValue("@Peso", peso);
                        cmd.Parameters.AddWithValue("@FechaEstimadaEntrega", fechaEstimadaEntrega);
                        cmd.Parameters.AddWithValue("@Estado", estado);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la encomienda: " + ex.Message);
            }
        }

        // Método para mostrar todas las encomiendas
        public DataTable MostrarEncomiendas()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("MostrarEncomiendas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las encomiendas: " + ex.Message);
            }
        }

        // Método para actualizar el estado de una encomienda
        public void ActualizarEstadoEncomienda(int id, string nuevoEstado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("ActualizarEstadoEncomienda", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el estado de la encomienda: " + ex.Message);
            }
        }

        // Método para obtener placas por tipo de transporte
        public DataTable ObtenerPlacasPorTipo(string tipoTransporte)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("ObtenerPlacasPorTipo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Tipo", tipoTransporte);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las placas: " + ex.Message);
            }
        }

        public DataTable MostrarEncomiendasPorEstadoYFecha(string estado, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("MostrarEncomiendasPorEstadoYFecha", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Estado", estado);
                        cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las encomiendas por estado y fecha: " + ex.Message);
            }
        }

        public DataTable ContarEncomiendasPorEstado(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("ContarEncomiendasPorEstado", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar las encomiendas por estado: " + ex.Message);
            }
        }



    }
}
