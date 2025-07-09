namespace CapaNegocios.Transportes
{
    public class Bus : Transporte
    {
        public string Placa { get; set; }
        public string Conductor { get; set; }

        public Bus() : base("Bus") { }

        public override decimal CalcularTarifa()
        {
            decimal tarifaBase = 500; // Establecer una tarifa base
            return tarifaBase + 50;

        }

        public override string ObtenerDescripcion()
        {
            return $"{base.ObtenerDescripcion()} | Conductor: {Conductor}, Placa: {Placa}";
        }
    }
}
