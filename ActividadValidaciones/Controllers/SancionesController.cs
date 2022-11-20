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
    public class SancionesController : ControllerBase
    {
        private readonly dbContextsanciones _context;
        public SancionesController(dbContextsanciones context)
        {
            _context = context;
        }
        // GET: api/<SedesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get()
        {
            var sanciones = await _context.Sanciones.Select(x =>
            new SancionesDTO
            {
                Numero = x.Numero,
                FechaExpedicion = x.FechaExpedicion,
                Sancion = x.Sancion,
                Observacion = x.Observacion,    
                Valor = x.Valor,
                idConductorIdentificacion = x.idConductorIdentificacion,
                //ConductorNombre = x.Conductor.Nombre

                }).ToListAsync();
                 if (sanciones == null)
                    {
                        return NotFound();
                    }
                 else
                     {
                        return sanciones;
                     }
        }



        // GET api/<SedesController>/5

        [HttpGet("{numero}")]
        public async Task<ActionResult<SancionesDTO>> Get(string numero)
        {
            var sanciones = await _context.Sanciones.Select(x =>
            new SancionesDTO
            {
                Numero = x.Numero,
                FechaExpedicion = x.FechaExpedicion,
                Sancion = x.Sancion,
                Observacion = x.Observacion,    
                Valor = x.Valor,
                idConductorIdentificacion = x.idConductorIdentificacion,

            }).FirstOrDefaultAsync(x => x.Numero == numero);
            if (sanciones == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(sanciones);
            }

        }


        // POST api/<SedesController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(SancionesDTO sanciones)
        {
            var entity = new Sanciones()
            {

                Numero = sanciones.Numero,
                FechaExpedicion = sanciones.FechaExpedicion,
                Sancion = sanciones.Sancion,
                Observacion = sanciones.Observacion,
                Valor = sanciones.Valor,
                idConductorIdentificacion = sanciones.idConductorIdentificacion,
             

            };
            _context.Sanciones.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;

        }

        // PUT api/<SedesController>/5
        [HttpPut("{numero}")]
        public async Task<HttpStatusCode> Put(SancionesDTO sanciones)
        {
            var entity = await _context.Sanciones.FirstOrDefaultAsync(s => s.Numero == sanciones.Numero);
            entity.Numero = sanciones.Numero;
            entity.FechaExpedicion = sanciones.FechaExpedicion;
            entity.Sancion = sanciones.Sancion;
            entity.Observacion = sanciones.Observacion;
            entity.Valor = sanciones.Valor;
            entity.idConductorIdentificacion = sanciones.idConductorIdentificacion;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }


        // DELETE api/<SedesController>/5
        [HttpDelete("{numero}")]
        public async Task<HttpStatusCode> Delete(string numero)
        {
            var entity = new Sanciones()
            {
                Numero = numero
            };
            _context.Sanciones.Attach(entity);
            _context.Sanciones.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
