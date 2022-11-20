namespace ActividadValidaciones.DTOs
{
    public class SancionesDTO
    {

        public string Numero { get; set; }

        public DateTime? FechaExpedicion { get; set; }
        public string Sancion { get; set; }
        public string Observacion { get; set; }
        public decimal Valor { get; set; }

        public string idConductorIdentificacion { get; set; }
      //  public string ConductorNombre { get; set; }
    }
}
