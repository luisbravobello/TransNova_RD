namespace CapaNegocios.Transportes
{
    public class Bus : Transporte
    {
        public string Placa { get; set; }
        public string Conductor { get; set; }

        public Bus() : base("Bus") { }

        public override decimal CalcularTarifa()
        {
            decimal tarifaBase = 450; // Establecer una tarifa base
            decimal tarifaCalculada = tarifaBase + 50;

            // La tarifa ya estará validada por la propiedad Tarifa en la clase base
            Tarifa = tarifaCalculada;  // Esto valida que no sea menor a 10

            return Tarifa;
        }

        public override string ObtenerDescripcion()
        {
            return $"{base.ObtenerDescripcion()} | Conductor: {Conductor}, Placa: {Placa}";
        }
    }
}
