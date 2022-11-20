using ActividadValidaciones.DAL.DBcontext;
using ActividadValidaciones.DAL.Entities;
using ActividadValidaciones.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ActividadValidaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ConductorController : ControllerBase
    {
        private readonly dbContextsanciones _context;
        public ConductorController(dbContextsanciones context)
        {
            _context = context;
        }
        // GET: api/<SedesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductorDTO>>> Get()
        {
            var  conductor = await _context.Conductor.Select(x =>
            new ConductorDTO
            {
                Identificacion = x.Identificacion,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Email = x.Email,
                FechaNacimiento = x.FechaNacimiento,
                Activo = x.Activo,
                MatriculaNumero = x.MatriculaNumero

            }).ToListAsync();
            if (conductor == null)
            {
                return NotFound();
            }
            else
            {
                return conductor;
            }
        }



        // GET api/<SedesController>/5

        [HttpGet("{identificacion}")]
        public async Task<ActionResult<ConductorDTO>> Get(string identificacion)
        {
            var conductor = await _context.Conductor.Select(x =>
            new ConductorDTO
            {
                Identificacion = x.Identificacion,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Email = x.Email,
                FechaNacimiento = x.FechaNacimiento,
                Activo = x.Activo,
                MatriculaNumero = x.MatriculaNumero

            }).FirstOrDefaultAsync(x => x.Identificacion == identificacion);
            if (conductor == null)
            {
                return NotFound();
            }
            else
            {
                return conductor;
            }

        }


        // POST api/<SedesController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(ConductorDTO conductor)
        {
            var entity = new Conductor()
            {

                Identificacion = conductor.Identificacion,
                Nombre = conductor.Nombre,
                Apellidos = conductor.Apellidos,
                Direccion = conductor.Direccion,
                Telefono = conductor.Telefono,
                Email = conductor.Email,
                FechaNacimiento = conductor.FechaNacimiento,
                Activo = conductor.Activo,
                MatriculaNumero = conductor.MatriculaNumero
            };
            _context.Conductor.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;

        }

        // PUT api/<SedesController>/5
        [HttpPut("{identificacion}")]
        public async Task<HttpStatusCode> Put(ConductorDTO conductor)
        {
            var entity = await _context.Conductor.FirstOrDefaultAsync(s => s.Identificacion == conductor.Identificacion);
            entity.Identificacion = conductor.Identificacion;
            entity.Nombre = conductor.Nombre;
            entity.Apellidos = conductor.Apellidos;
            entity.Direccion = conductor.Direccion;
            entity.Telefono = conductor.Telefono;
            entity.Email = conductor.Email;
            entity.FechaNacimiento = conductor.FechaNacimiento;
            entity.Activo = conductor.Activo;
            entity.MatriculaNumero = conductor.MatriculaNumero;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }


        // DELETE api/<SedesController>/5
        [HttpDelete("{identificacion}")]
        public async Task<HttpStatusCode> Delete(string identificacion)
        {
            var entity = new Conductor()
            {
                Identificacion = identificacion
            };
            _context.Conductor.Attach(entity);
            _context.Conductor.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
