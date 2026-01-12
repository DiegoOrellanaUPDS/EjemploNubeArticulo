using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Entidades;

namespace simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsistenciaArchivoController : ControllerBase
    {
        private readonly simpleContext _context;

        public ConsistenciaArchivoController(simpleContext context)
        {
            _context = context;
        }

        /// GET: api/Archivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsistenciaArchivo>>> GetArchivos()
        {
            return await _context.ConsistenciaArchivos.ToListAsync();
        }


        // POST: api/Archivos
        [HttpPost]
        public async Task<ActionResult<ConsistenciaArchivo>> PostArchivos(ConsistenciaArchivo archivo)
        {
            _context.ConsistenciaArchivos.Add(archivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchivos", new { id = archivo.Id_Archivo }, archivo);
        }

    }
}
