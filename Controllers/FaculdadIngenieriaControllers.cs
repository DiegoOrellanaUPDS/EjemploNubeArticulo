using Microsoft.AspNetCore.Mvc;
using simple.Data;
using simple.Models;
using System.Linq;

namespace simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultadIngenieriaCarrerasController : ControllerBase
    {
        private readonly simpleContext _context;

        public FacultadIngenieriaCarrerasController(simpleContext context)
        {
            _context = context;
        }

        // POST: Crear nueva carrera
        [HttpPost]
        public IActionResult CrearCarrera([FromBody] FacultadIngenieriaCarrera carrera)
        {
            if (carrera == null)
                return BadRequest("Datos inválidos");

            if (string.IsNullOrWhiteSpace(carrera.Nombre) || string.IsNullOrWhiteSpace(carrera.Modalidad))
                return BadRequest("Nombre y Modalidad son requeridos");

            _context.FacultadIngenieriaCarreras.Add(carrera);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObtenerCarreras), new { id = carrera.Id }, carrera);
        }

        // GET: Obtener todas las carreras
        [HttpGet]
        public IActionResult ObtenerCarreras()
        {
            var carreras = _context.FacultadIngenieriaCarreras.ToList();
            return Ok(carreras);
        }
    }
}