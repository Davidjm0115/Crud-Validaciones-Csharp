namespace ActividadValidaciones.DTOs
{
    public class ConductorDTO
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool Activo { get; set; }
        public string MatriculaNumero { get; set; } 
    }
}
