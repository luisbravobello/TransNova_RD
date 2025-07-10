namespace CapaNegocios.Transportes
{
    public class Taxi : Transporte
    {
        public string Placa { get; set; }
        public string Conductor { get; set; }

        public Taxi() : base("Taxi") { }

        public override decimal CalcularTarifa()
        {
            decimal tarifaBase = 300.00m; // Establecer una tarifa base para el Taxi
            decimal tarifaCalculada = tarifaBase;

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
