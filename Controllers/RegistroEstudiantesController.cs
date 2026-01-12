using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Models;

namespace simple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroEstudiantesController : ControllerBase
    {
        private readonly simpleContext _context;

        public RegistroEstudiantesController(simpleContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<RegistroEstudiante>> PostRegistroEstudiante(RegistroEstudiante estudiante)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.RegistroEstudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostRegistroEstudiante), 
                new { id = estudiante.Id }, 
                estudiante);
        }
    }
}
