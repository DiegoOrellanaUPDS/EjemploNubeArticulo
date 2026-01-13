using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Entidades;

namespace simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SistemasAlumnosController : ControllerBase
    {
        private readonly simpleContext _context;

        public SistemasAlumnosController(simpleContext context)
        {
            _context = context;
        }

        // GET: api/SistemasAlumnos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.SistemasAlumnos.ToListAsync());
        }

        // POST: api/SistemasAlumnos
        [HttpPost]
        public async Task<IActionResult> Create(SistemasAlumno alumno)
        {
            _context.SistemasAlumnos.Add(alumno);
            await _context.SaveChangesAsync();
            return Ok(alumno);
        }
    }
}
