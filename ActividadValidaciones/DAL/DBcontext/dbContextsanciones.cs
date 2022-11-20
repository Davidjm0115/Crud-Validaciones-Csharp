using ActividadValidaciones.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActividadValidaciones.DAL.DBcontext
{
    public class dbContextsanciones : DbContext //DbContext clase oculta que se crea al usar EntityFrameworkCore
    {
        //consrructor y se usa DbContextOptions para manipular
        public dbContextsanciones(DbContextOptions<dbContextsanciones> options) : base(options) { }

        //clases a maniplar
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Conductor> Conductor { get; set; }
        public virtual DbSet<Sanciones> Sanciones { get; set; }
    }
}
