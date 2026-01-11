using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Entidades;
using simple.Models;

namespace simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProduccionContenidoController: ControllerBase
    {
        private readonly simpleContext _context;
        public ProduccionContenidoController(simpleContext context)
        {
            _context = context;
        }
        // POST: api/ProduccionContenido
        [HttpPost]
        public async Task<IActionResult> PostProduccionContenido(ProduccionContenido contenido)
        {
            _context.ProduccionContenidos.Add(contenido);
            await  _context.SaveChangesAsync();
            return Ok(contenido);
        }
    }
}