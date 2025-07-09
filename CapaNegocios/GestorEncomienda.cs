using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class GestorEncomienda
    {
        private readonly CD_Encomienda cdEncomienda;

        public GestorEncomienda()
        {
            cdEncomienda = new CD_Encomienda(); // Instanciamos la capa de datos
        }

        // Método para insertar una nueva encomienda
        public void Insertar(Encomienda encomienda)
        {
            try
            {
                // Llamar al método InsertarEncomienda de la capa de datos
                cdEncomienda.InsertarEncomienda(encomienda.CodigoSeguimiento, encomienda.TipoTransporte, encomienda.Placa,
                                                 encomienda.Remitente, encomienda.Destinatario, encomienda.DireccionEntrega,
                                                 encomienda.Peso, encomienda.FechaEstimadaEntrega, encomienda.Estado);
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
                // Llamar a la capa de datos para obtener las encomiendas
                return cdEncomienda.MostrarEncomiendas();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las encomiendas", ex);
            }
        }


        // Método para actualizar el estado de una encomienda
        public void ActualizarEstadoEncomienda(int id, string nuevoEstado)
        {
            try
            {
                // Llamamos a la capa de datos para actualizar el estado
                cdEncomienda.ActualizarEstadoEncomienda(id, nuevoEstado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el estado de la encomienda", ex);
            }
        }

        public DataTable MostrarEncomiendasPorEstadoYFecha(string estado, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                return cdEncomienda.MostrarEncomiendasPorEstadoYFecha(estado, fechaDesde, fechaHasta);
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
                return cdEncomienda.ContarEncomiendasPorEstado(fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar las encomiendas por estado: " + ex.Message);
            }
        }



        // Método para obtener las placas de transportes por tipo (utilizado en el ComboBox)
        public DataTable ObtenerPlacasPorTipo(string tipoTransporte)
        {
            try
            {
                return cdEncomienda.ObtenerPlacasPorTipo(tipoTransporte);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las placas por tipo", ex);
            }
        }
    }
}
