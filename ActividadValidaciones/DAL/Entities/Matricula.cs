using System.ComponentModel.DataAnnotations;

namespace ActividadValidaciones.DAL.Entities
{
    public class Matricula
    {
        //se crean los campos  de las tablas igual que sql
        
        //public int Id { get; set; }

        [Key]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(15, ErrorMessage = "maximo 20 caracteres")]
        public string Numero{ get; set; }

        public DateTime? FechaExpedicion { get; set; }
        public DateTime? ValidaHasta { get; set; }

        public bool Activo { get; set; }

    }
}
