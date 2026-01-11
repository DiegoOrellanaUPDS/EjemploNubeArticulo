using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple.Data;
using simple.Entidades;

namespace simple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecretariaGeneralDocumentoController : ControllerBase
    {
        private readonly simpleContext _context;

        public SecretariaGeneralDocumentoController(simpleContext context)
        {
            _context = context;
        }

        // ✅ GET: api/SecretariaGeneralDocumento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SecretariaGeneralDocumento>>> GetDocumentos()
        {
            return await _context.SecretariaGeneralDocumentos.ToListAsync();
        }

        // ✅ GET: api/SecretariaGeneralDocumento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SecretariaGeneralDocumento>> GetDocumento(int id)
        {
            var documento = await _context.SecretariaGeneralDocumentos.FindAsync(id);

            if (documento == null)
                return NotFound();

            return documento;
        }

        // ✅ POST: api/SecretariaGeneralDocumento
        [HttpPost]
        public async Task<ActionResult<SecretariaGeneralDocumento>> PostDocumento(SecretariaGeneralDocumento documento)
        {
            _context.SecretariaGeneralDocumentos.Add(documento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocumento), new { id = documento.Id }, documento);
        }

        // ✅ PUT: api/SecretariaGeneralDocumento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumento(int id, SecretariaGeneralDocumento documento)
        {
            if (id != documento.Id)
                return BadRequest();

            _context.Entry(documento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE: api/SecretariaGeneralDocumento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumento(int id)
        {
            var documento = await _context.SecretariaGeneralDocumentos.FindAsync(id);
            if (documento == null)
                return NotFound();

            _context.SecretariaGeneralDocumentos.Remove(documento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
