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
            return tarifaBase + ((Estaciones ?? 0) * 2);
        }

        public override string ObtenerDescripcion()
        {
            return $"Metro Línea {Linea} - {Estaciones} estaciones, Tarifa: RD${CalcularTarifa()}";
        }
    }
}

