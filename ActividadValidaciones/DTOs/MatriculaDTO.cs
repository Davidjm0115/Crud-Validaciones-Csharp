﻿namespace ActividadValidaciones.DTOs
{
    public class MatriculaDTO
    {
        public string Numero { get; set; }

        public DateTime? FechaExpedicion { get; set; }

        public DateTime? ValidaHasta { get; set; }

        public bool Activo { get; set; }
    }
}
