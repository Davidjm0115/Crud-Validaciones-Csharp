using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActividadValidaciones.DAL.Entities
{
    public class Sanciones
    {
        //se crean los campos  de las tablas igual que sql

       // public int Id { get; set; }

        [Key]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(15, ErrorMessage = "maximo 15 caracteres")]
        public string Numero { get; set; }

        public DateTime? FechaExpedicion { get; set; }
        public string Sancion { get; set; }
        public string Observacion { get; set; }
        public decimal Valor { get; set; }

        [ForeignKey("idConductorIdentificacion")]
        public string idConductorIdentificacion { get; set; }
        public virtual Conductor idConductor { get; set; } //es como relacionar con sedes referencias de foreing
    }
}
