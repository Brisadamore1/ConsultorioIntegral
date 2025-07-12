using Backend.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModalidadPagoController : ControllerBase
    {
        private readonly ConsultorioContext _context;
        public ModalidadPagoController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: api/ModalidadPago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModalidadPago>>> GetModalidadesPago([FromQuery] string? filtro = "")
        {
            return await _context.ModalidadesPago
               .Where(c => c.Modalidad.ToUpper().Contains(filtro.ToUpper()))
               .ToListAsync();
        }

        // GET: api/ModalidadPago/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModalidadPago>> GetModalidadPago(int id)
        {
            var modalidadPago = await _context.ModalidadesPago.FindAsync(id);

            if (modalidadPago == null)
            {
                return NotFound();
            }

            return modalidadPago;
        }

        // PUT: api/ModalidadPago/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModalidadPago(int? id, ModalidadPago modalidadPago)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (modalidadPago == null)
            {
                throw new ArgumentNullException();
            }
            if (id != modalidadPago.Id)
            {
                return BadRequest();
            }

            _context.Entry(modalidadPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModalidadPagoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactosEmergencia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModalidadPago>> PostModalidadPago(ModalidadPago modalidadPago)
        {
            _context.ModalidadesPago.Add(modalidadPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModalidadPago", new { id = modalidadPago.Id }, modalidadPago);
        }

        // DELETE: api/ModalidadesPago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModalidadPago(int id)
        {
            var modalidadPago = await _context.ModalidadesPago.FindAsync(id);
            if (modalidadPago == null)
            {
                return NotFound();
            }
            modalidadPago.Eliminado = true;
            _context.ModalidadesPago.Update(modalidadPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ModalidadPagoExists(int? id)
        {
            return _context.ModalidadesPago.Any(e => e.Id == id);
        }
    }
}
