using System;

namespace CapaNegocios.Transportes
{
    public abstract class Transporte
    {
        // Propiedades comunes (con encapsulación)
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Ruta { get; set; }
        public string LugarInicio { get; set; }
        public string DestinoFin { get; set; }

        private TimeSpan _horaInicio;
        public TimeSpan HoraInicio
        {
            get => _horaInicio;
            set
            {
                if (value < TimeSpan.Zero || value >= TimeSpan.FromHours(24))
                    throw new ArgumentException("La hora de inicio no es válida.");
                _horaInicio = value;
            }
        }

        public int Capacidad { get; set; }

        // La Placa es opcional (puede ser null)
        public string? Placa { get; set; }

        private decimal _tarifa;
        public decimal Tarifa
        {
            get => _tarifa;
            set
            {
                const decimal tarifaMinima = 10.00m;
                if (value < tarifaMinima)
                {
                    throw new ArgumentException($"La tarifa no puede ser menor a {tarifaMinima:C}.");
                }
                _tarifa = value;
            }
        }

        // Constructor base
        public Transporte(string tipo)
        {
            Tipo = tipo;
        }

        // Método abstracto: debe implementarse en cada transporte
        public abstract decimal CalcularTarifa();

        // Método virtual: puede sobrescribirse si se necesita
        public virtual string ObtenerDescripcion()
        {
            return $"{Tipo} - Ruta: {Ruta}, Desde: {LugarInicio} hasta {DestinoFin}, Tarifa: {Tarifa:C}";
        }
    }   
}