using CapaDatos;
using CapaNegocios.Transportes;
using System;
using System.Data;

namespace CapaNegocios
{
    public class GestorTransporte
    {
        private readonly CD_Transporte cdTransporte;

        public GestorTransporte()
        {
            cdTransporte = new CD_Transporte(); // Instanciamos la capa de datos
        }

        // Método para obtener todos los transportes
        public DataTable ObtenerTransportes()
        {
            try
            {
                // Llamamos a la capa de datos para obtener los transportes
                return cdTransporte.MostrarTransportes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los transportes", ex);
            }
        }

       
        public DataTable ObtenerTransportesPorTipo(string tipo)
        {
            try
            {
                // Llamamos a la capa de datos para obtener los transportes filtrados por tipo
                return cdTransporte.MostrarTransportesPorTipo(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los transportes por tipo", ex);
            }
        }

        // Método para insertar un nuevo transporte
        public void InsertarTransporte(string tipo, string placa, string conductor, int capacidad, string ruta, string inicio, string destino, TimeSpan hora, decimal tarifa, string? linea, int? estaciones, int? vagones)
        {
            try
            {
                // Llamamos a la capa de datos para insertar el transporte
                cdTransporte.InsertarTransporte(tipo, placa, conductor, capacidad, ruta, inicio, destino, hora, tarifa, linea, estaciones, vagones);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el transporte", ex);
            }
        }

        // Método para editar un transporte existente
        public void EditarTransporte(int id, string tipo, string placa, string conductor, int capacidad, string ruta, string inicio, string destino, TimeSpan hora, decimal tarifa, string? linea, int? estaciones, int? vagones)
        {
            try
            {
                // Llamamos a la capa de datos para editar el transporte
                cdTransporte.EditarTransporte(id, tipo, placa, conductor, capacidad, ruta, inicio, destino, hora, tarifa, linea, estaciones, vagones);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el transporte", ex);
            }
        }
        public DataTable ObtenerTransportePorId(int id)
        {
            try
            {
                return cdTransporte.ObtenerTransportePorId(id); // Correcto: sin "s"
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el transporte por ID", ex);
            }
        }


        // Método para eliminar un transporte
        public void EliminarTransporte(int id)
        {
            try
            {
                // Llamamos a la capa de datos para eliminar el transporte
                cdTransporte.EliminarTransporte(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el transporte", ex);
            }
        }
    }
}
