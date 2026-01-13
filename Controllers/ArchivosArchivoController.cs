using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Entidades;

namespace simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchivosArchivoController : ControllerBase
    {
        private readonly simpleContext _context;

        public ArchivosArchivoController(simpleContext context)
        {
            _context = context;
        }

        // GET: api/ArchivosArchivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchivosArchivo>>> GetArchivos()
        {
            return await _context.ArchivosArchivos.ToListAsync();
        }

        // GET: api/ArchivosArchivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchivosArchivo>> GetArchivo(int id)
        {
            var archivo = await _context.ArchivosArchivos.FindAsync(id);

            if (archivo == null)
            {
                return NotFound();
            }

            return archivo;
        }

        // POST: api/ArchivosArchivo
        [HttpPost]
        public async Task<ActionResult<ArchivosArchivo>> PostArchivo(ArchivosArchivo archivo)
        {
            // Valores por defecto
            if (archivo.FechaCreacion == default)
                archivo.FechaCreacion = DateTime.Now;
            
            if (string.IsNullOrEmpty(archivo.Estado))
                archivo.Estado = "Activo";

            _context.ArchivosArchivos.Add(archivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArchivo), new { id = archivo.Id }, archivo);
        }
    }
}
