using Backend.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EstadosTurnoController : ControllerBase
    {
        private readonly ConsultorioContext _context;

        public EstadosTurnoController(ConsultorioContext context)
        {
            _context = context;
        }

        
        // GET: api/EstadoTurno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoTurno>>> GetEstadosTurno([FromQuery] string? filtro = "")
        {
            return await _context.EstadosTurno
               .Where(c => c.Estado.ToUpper().Contains(filtro.ToUpper()))
               .ToListAsync();
        }

        // GET: api/EstadoTurno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoTurno>> GetEstadoTurno(int id)
        {
            var estadoTurno = await _context.EstadosTurno.FindAsync(id);

            if (estadoTurno == null)
            {
                return NotFound();
            }

            return estadoTurno;
        }
        // PUT: api/EstadosTurno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoTurno(int id, EstadoTurno estadoTurno)
        {
            if (id != estadoTurno.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoTurno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoTurnoExists(id))
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
        // POST: api/EstadosTurno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoTurno>> PostEstadoTurno(EstadoTurno estadoTurno)
        {
            _context.EstadosTurno.Add(estadoTurno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoTurno", new { id = estadoTurno.Id }, estadoTurno);
        }

        // DELETE: api/EstadosTurno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoTurno(int id)
        {
            var estadoTurno = await _context.EstadosTurno.FindAsync(id);
            if (estadoTurno == null)
            {
                return NotFound();
            }
            estadoTurno.Eliminado = true;
            _context.EstadosTurno.Update(estadoTurno);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool EstadoTurnoExists(int id)
        {
            return _context.EstadosTurno.Any(e => e.Id == id);
        }
    }
}
