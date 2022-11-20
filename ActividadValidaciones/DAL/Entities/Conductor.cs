using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActividadValidaciones.DAL.Entities
{
    public class Conductor
    {
        //se crean los campos  de las tablas igual que sql

       // public int Id { get; set; }

        [Key]
        [StringLength(15, ErrorMessage = "maximo 15 caracteres")]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("MatriculaNumero")]
        public string MatriculaNumero { get; set; }
        public virtual Matricula Matricula { get; set; } //es como relacionar con sedes referencias de foreing

    }
}
