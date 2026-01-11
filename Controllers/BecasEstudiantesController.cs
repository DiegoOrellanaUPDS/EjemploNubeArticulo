using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Entidades;

namespace simple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BecasEstudiantesController : ControllerBase
    {
        private readonly simpleContext _context;

        public BecasEstudiantesController(simpleContext context)
        {
            _context = context;
        }

        // POST: api/BecasEstudiantes
        [HttpPost]
        public async Task<ActionResult<BecasEstudiante>> PostBecasEstudiante(BecasEstudiante becasEstudiante)
        {
            _context.BecasEstudiantes.Add(becasEstudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBecasEstudiante", new { id = becasEstudiante.Id }, becasEstudiante);
        }

        // GET: api/BecasEstudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BecasEstudiante>> GetBecasEstudiante(int id)
        {
            var becasEstudiante = await _context.BecasEstudiantes.FindAsync(id);

            if (becasEstudiante == null)
            {
                return NotFound();
            }

            return becasEstudiante;
        }
    }
}