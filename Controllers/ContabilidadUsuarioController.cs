using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Models;

namespace simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContabilidadUsuarioController : ControllerBase
    {
        private readonly simpleContext _context;
        public ContabilidadUsuarioController(simpleContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContabilidadUsuario>> GetContabilidadUsuario(int id)
        {
            var usuario = await _context.ContabilidadUsuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
        // POST: api/ContabilidadUsuario
        [HttpPost]
        public async Task<IActionResult> PostContabilidadUsuario(ContabilidadUsuario usuario)
        {
            // Valores por defecto
            if (usuario.CON_FechaRegistro == default)
                usuario.CON_FechaRegistro = DateTime.Now;
            
            usuario.CON_Departamento = "Contabilidad";
            usuario.CON_Activo = true;
            
            _context.ContabilidadUsuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }
    }
}
