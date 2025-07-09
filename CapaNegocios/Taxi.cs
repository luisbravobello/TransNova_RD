namespace CapaNegocios.Transportes
{
    public class Taxi : Transporte
    {
        public string Placa { get; set; }
        public string Conductor { get; set; }

        public Taxi() : base("Taxi") { }

        public override decimal CalcularTarifa()
        {
            return 300.00m; // Tarifa más alta por ser transporte privado
        }

        public override string ObtenerDescripcion()
        {
            return $"{base.ObtenerDescripcion()} | Taxi conducido por {Conductor}, Placa: {Placa}";
        }
    }
}
