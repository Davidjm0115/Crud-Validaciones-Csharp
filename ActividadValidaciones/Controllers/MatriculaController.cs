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
    public class MatriculaController : ControllerBase
    {
        private readonly dbContextsanciones _context;
        public MatriculaController(dbContextsanciones context)
        {
            _context = context;
        }
        // GET: api/<SedesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDTO>>> Get()
        {
            var matricula = await _context.Matricula.Select(x =>
            new MatriculaDTO
            {
                Numero = x.Numero,
                FechaExpedicion = x.FechaExpedicion,
                ValidaHasta = x.ValidaHasta,
                Activo = x.Activo
            }).ToListAsync();
            if (matricula == null)
            {
                return NotFound();
            }
            else
            {
                return matricula;
            }
        }



        // GET api/<SedesController>/5

        [HttpGet("{numero}")]
        public async Task<ActionResult<MatriculaDTO>> Get(string numero)
        {
            var matricula = await _context.Matricula.Select(x =>
            new MatriculaDTO
            {
                Numero = x.Numero,
                FechaExpedicion = x.FechaExpedicion,
                ValidaHasta = x.ValidaHasta,
                Activo = x.Activo
            }).FirstOrDefaultAsync(x => x.Numero == numero);
            if (matricula == null)
            {
                return NotFound();
            }
            else
            {
                return matricula;
            }

        }


        // POST api/<SedesController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(MatriculaDTO matricula)
        {
            var entity = new Matricula()
            {
                Numero = matricula.Numero,
                FechaExpedicion = matricula.FechaExpedicion,
                ValidaHasta = matricula.ValidaHasta,
                Activo = matricula.Activo
            };
            _context.Matricula.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;

        }

        // PUT api/<SedesController>/5
        [HttpPut("{numero}")]
        public async Task<HttpStatusCode> Put(MatriculaDTO matricula)
        {
            var entity = await _context.Matricula.FirstOrDefaultAsync(s => s.Numero == matricula.Numero);
            entity.Numero = matricula.Numero;
            entity.FechaExpedicion = matricula.FechaExpedicion;
            entity.ValidaHasta = matricula.ValidaHasta;
            entity.Activo = matricula.Activo;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        // DELETE api/<SedesController>/5
        [HttpDelete("{numero}")]
        public async Task<HttpStatusCode> Delete(string numero)
        {
            var entity = new Matricula()
            {
                Numero = numero
            };
            _context.Matricula.Attach(entity);
            _context.Matricula.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
