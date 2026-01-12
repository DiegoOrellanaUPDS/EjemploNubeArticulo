using Microsoft.AspNetCore.Mvc;
using simple.Data;
using simple.Models;
using Microsoft.EntityFrameworkCore;

namespace simple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectoradoController : ControllerBase
    {
        private readonly simpleContext _context;

        public RectoradoController(simpleContext context)
        {
            _context = context;
        }

        // POST: api/Rectorado
        // POST: api/RectoradoAutoridades
        [HttpPost]
        public async Task<ActionResult<RectoradoAutoridad>> PostAutoridad(RectoradoAutoridad autoridad)
        {
            // Agregamos la autoridad recibida a la base de datos
            _context.RectoradoAutoridades.Add(autoridad);
            
            // Guardamos los cambios
            await _context.SaveChangesAsync();

            // Retornamos el objeto creado
            return Ok(autoridad);
        }
    }
}