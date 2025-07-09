namespace CapaNegocios
{
    public class Encomienda
    {
        public int Id { get; set; }
        public string CodigoSeguimiento { get; set; }
        public string TipoTransporte { get; set; }
        public string Placa { get; set; }
        public string Remitente { get; set; }
        public string Destinatario { get; set; }
        public string DireccionEntrega { get; set; }
        public decimal Peso { get; set; }
        public DateTime FechaEstimadaEntrega { get; set; }
        public string Estado { get; set; }

        // Constructor por defecto
        public Encomienda() { }

        // Constructor con parámetros
        public Encomienda(string codigoSeguimiento, string tipoTransporte, string placa, string remitente, string destinatario,
                          string direccionEntrega, decimal peso, DateTime fechaEstimadaEntrega, string estado)
        {
            CodigoSeguimiento = codigoSeguimiento;
            TipoTransporte = tipoTransporte;
            Placa = placa;
            Remitente = remitente;
            Destinatario = destinatario;
            DireccionEntrega = direccionEntrega;
            Peso = peso;
            FechaEstimadaEntrega = fechaEstimadaEntrega;
            Estado = estado;
        }
    }
}
