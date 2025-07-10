namespace CapaNegocios.Transportes
{
    public class Metro : Transporte
    {
        public string Linea { get; set; }
        public int? Estaciones { get; set; }
        public int? CapacidadVagones { get; set; }

        public Metro() : base("Metro") { }

        public override decimal CalcularTarifa()
        {
            decimal tarifaBase = 0; // Valor base para el Metro
            decimal tarifaCalculada = tarifaBase + ((Estaciones ?? 0) * 2); // Cada estación suma 2 unidades a la tarifa

            // La tarifa ya estará validada por la propiedad Tarifa en la clase base
            Tarifa = tarifaCalculada;  // Esto valida que no sea menor a 10

            return Tarifa;
        }

        public override string ObtenerDescripcion()
        {
            return $"Metro Línea {Linea} - {Estaciones} estaciones, Tarifa: RD${CalcularTarifa()}";
        }
    }
}
