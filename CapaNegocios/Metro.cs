using CapaNegocios.Transportes;

public class Metro : Transporte
{
    public string Linea { get; set; }
    public int? Estaciones { get; set; }
    public int? CapacidadVagones { get; set; }

    public Metro() : base("Metro") { }

    // Método para calcular tarifa en Metro
    public override decimal CalcularTarifa()
    {
        decimal tarifaBase = 500; // Valor base para el Metro
        decimal tarifaCalculada = tarifaBase + ((Estaciones ?? 0) * 2); // Cada estación suma 2 unidades a la tarifa

        // Asegurarse de que la tarifa cumpla con la validación de la clase base
        Tarifa = tarifaCalculada;  // Esto valida que no sea menor a 10

        return Tarifa;
    }

    // Sobrescribir el método ObtenerDescripcion para Metro
    public override string ObtenerDescripcion()
    {
        return $"Metro Línea {Linea} - {Estaciones} estaciones, Tarifa: RD${CalcularTarifa()}";
    }
}
