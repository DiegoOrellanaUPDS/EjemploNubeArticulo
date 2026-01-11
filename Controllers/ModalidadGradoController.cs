using Microsoft.AspNetCore.Mvc;
using simple.Data;
using simple.Entidades;

namespace simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModalidadesGradoController : ControllerBase
    {
        private readonly simpleContext _context;

        public ModalidadesGradoController(simpleContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CrearModalidad([FromBody] ModalidadGrado modalidad)
        {
            _context.ModalidadesGrado.Add(modalidad);
            _context.SaveChanges();
            return CreatedAtAction(nameof(CrearModalidad), new { id = modalidad.Id }, modalidad);
        }
    }
}
