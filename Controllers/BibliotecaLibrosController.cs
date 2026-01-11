using Microsoft.AspNetCore.Mvc;
using simple.Data;
using simple.Entidades;

namespace simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BibliotecaLibrosController : ControllerBase
    {
        private readonly simpleContext _context;

        public BibliotecaLibrosController(simpleContext context)
        {
            _context = context;
        }

        // POST: api/BibliotecaLibros
        [HttpPost]
        public async Task<IActionResult> Post(BibliotecaLibro libro)
        {
            _context.BibliotecaLibros.Add(libro);
            await _context.SaveChangesAsync();
            return Ok(libro);
        }
    }
}
