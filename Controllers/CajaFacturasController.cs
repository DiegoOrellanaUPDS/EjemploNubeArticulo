using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Models;

namespace simple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajaFacturasController : ControllerBase
    {
        private readonly simpleContext _context;

        public CajaFacturasController(simpleContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene la lista de facturas activas.
        /// </summary>
        [HttpGet("GET")]
        public async Task<IActionResult> GetFacturas()
        {
            var facturas = await _context.CajaFacturas
                .Where(f => f.Estado)
                .ToListAsync();

            return Ok(facturas);
        }

        /// <summary>
        /// Obtiene una factura por su ID.
        /// </summary>
        [HttpGet("GET/{id}")]
        public async Task<IActionResult> GetFactura(int id)
        {
            var factura = await _context.CajaFacturas.FindAsync(id);

            if (factura is null || !factura.Estado)
                return NotFound($"No se encontró la factura con ID {id}.");

            return Ok(factura);
        }

        /// <summary>
        /// Obtiene la lista de facturas borradas.
        /// </summary>
        [HttpGet("GET/Borrados")]
        public async Task<IActionResult> GetFacturasBorradas()
        {
            var facturas = await _context.CajaFacturas
                .Where(f => !f.Estado)
                .ToListAsync();

            return Ok(facturas);
        }

        /// <summary>
        /// Crea una nueva factura.
        /// </summary>
        [HttpPost("POST")]
        public async Task<IActionResult> PostFactura([FromBody] CajaFactura factura)
        {
            if (string.IsNullOrWhiteSpace(factura.NumeroFactura))
                return BadRequest("El número de factura es obligatorio.");

            factura.Total = factura.SubTotal + factura.Impuesto;
            factura.Estado = true;

            _context.CajaFacturas.Add(factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetFactura),
                new { id = factura.Id },
                factura
            );
        }

        /// <summary>
        /// Actualiza una factura existente.
        /// </summary>
        [HttpPut("PUT/{id}")]
        public async Task<IActionResult> PutFactura(int id, [FromBody] CajaFactura factura)
        {
            if (id != factura.Id)
                return BadRequest("El ID no coincide.");

            var facturaDb = await _context.CajaFacturas.FindAsync(id);
            if (facturaDb is null)
                return NotFound($"No se encontró la factura con ID {id}.");

            facturaDb.NumeroFactura = factura.NumeroFactura;
            facturaDb.FechaFactura = factura.FechaFactura;
            facturaDb.SubTotal = factura.SubTotal;
            facturaDb.Impuesto = factura.Impuesto;
            facturaDb.Total = factura.SubTotal + factura.Impuesto;
            facturaDb.Observaciones = factura.Observaciones;

            await _context.SaveChangesAsync();

            return Ok(facturaDb);
        }

        /// <summary>
        /// Eliminación lógica de una factura.
        /// </summary>
        [HttpDelete("DEL/{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            var factura = await _context.CajaFacturas.FindAsync(id);
            if (factura is null)
                return NotFound($"No se encontró la factura con ID {id}.");

            factura.Estado = false;
            await _context.SaveChangesAsync();

            return Ok(factura);
        }

        /// <summary>
        /// Reactiva una factura borrada.
        /// </summary>
        [HttpPut("HAB/{id}")]
        public async Task<IActionResult> HabilitarFactura(int id)
        {
            var factura = await _context.CajaFacturas.FindAsync(id);
            if (factura is null)
                return NotFound($"No se encontró la factura con ID {id}.");

            factura.Estado = true;
            await _context.SaveChangesAsync();

            return Ok(factura);
        }
    }
}
