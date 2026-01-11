using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Entidades;

namespace simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContabilidadFacturaController : ControllerBase
    {
        private readonly simpleContext _context;

        public ContabilidadFacturaController(simpleContext context)
        {
            _context = context;
        }

        // POST: api/ContabilidadFactura
        [HttpPost]
        public async Task<IActionResult> PostContabilidadFactura(ContabilidadFactura factura)
        {
            _context.ContabilidadFacturas.Add(factura);
            await _context.SaveChangesAsync();

            return Ok(factura);
        }
    }
}