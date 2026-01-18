using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtunivTalleresController : ControllerBase
    {
        private readonly simpleContext _context;

        public ExtunivTalleresController(simpleContext context)
        {
            _context = context;
        }

        // GET: api/ExtunivTalleres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExtunivTaller>>> GetExtunivTalleres()
        {
            return await _context.ExtunivTalleres.ToListAsync();
        }

        // GET: api/ExtunivTalleres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExtunivTaller>> GetExtunivTaller(int id)
        {
            var extunivTaller = await _context.ExtunivTalleres.FindAsync(id);

            if (extunivTaller == null)
            {
                return NotFound();
            }

            return extunivTaller;
        }

        // GET: api/ExtunivTalleres/activos
        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<ExtunivTaller>>> GetTalleresActivos()
        {
            return await _context.ExtunivTalleres
                .Where(t => t.Activo && t.FechaFin >= DateTime.Now)
                .ToListAsync();
        }

        // GET: api/ExtunivTalleres/disponibles
        [HttpGet("disponibles")]
        public async Task<ActionResult<IEnumerable<ExtunivTaller>>> GetTalleresDisponibles()
        {
            return await _context.ExtunivTalleres
                .Where(t => t.Activo && 
                           t.FechaFin >= DateTime.Now && 
                           t.InscritosActuales < t.CupoMaximo)
                .ToListAsync();
        }

        // PUT: api/ExtunivTalleres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtunivTaller(int id, ExtunivTaller extunivTaller)
        {
            if (id != extunivTaller.Id)
            {
                return BadRequest();
            }

            extunivTaller.FechaActualizacion = DateTime.Now;
            _context.Entry(extunivTaller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtunivTallerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ExtunivTalleres
        [HttpPost]
        public async Task<ActionResult<ExtunivTaller>> PostExtunivTaller(ExtunivTaller extunivTaller)
        {
            extunivTaller.FechaCreacion = DateTime.Now;
            _context.ExtunivTalleres.Add(extunivTaller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtunivTaller", new { id = extunivTaller.Id }, extunivTaller);
        }

        // DELETE: api/ExtunivTalleres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExtunivTaller(int id)
        {
            var extunivTaller = await _context.ExtunivTalleres.FindAsync(id);
            if (extunivTaller == null)
            {
                return NotFound();
            }

            // En lugar de borrar, desactivamos
            extunivTaller.Activo = false;
            extunivTaller.FechaActualizacion = DateTime.Now;
            _context.Entry(extunivTaller).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/ExtunivTalleres/5/inscribir
        [HttpPost("{id}/inscribir")]
        public async Task<IActionResult> InscribirParticipante(int id)
        {
            var taller = await _context.ExtunivTalleres.FindAsync(id);
            
            if (taller == null || !taller.Activo)
            {
                return NotFound("Taller no encontrado o inactivo");
            }

            if (taller.InscritosActuales >= taller.CupoMaximo)
            {
                return BadRequest("Cupo completo");
            }

            if (taller.FechaFin < DateTime.Now)
            {
                return BadRequest("Taller ya finalizado");
            }

            taller.InscritosActuales++;
            taller.FechaActualizacion = DateTime.Now;
            
            await _context.SaveChangesAsync();

            return Ok(new { 
                mensaje = "Inscripción exitosa", 
                cuposDisponibles = taller.CupoMaximo - taller.InscritosActuales 
            });
        }

        private bool ExtunivTallerExists(int id)
        {
            return _context.ExtunivTalleres.Any(e => e.Id == id);
        }
    }
}