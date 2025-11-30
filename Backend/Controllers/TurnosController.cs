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
    public class TurnosController : ControllerBase
    {
        private readonly ConsultorioContext _context;
        public TurnosController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: api/Turnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnos([FromQuery] string? filtro = "")
        {
            // Incluir tanto Paciente como Profesional en la consulta
            return await _context.Turnos
                .Include(c => c.Paciente)
                .Include(c => c.Profesional)
                .Where(c => string.IsNullOrEmpty(filtro)
                            || (c.Paciente != null && c.Paciente.Nombre != null && c.Paciente.Nombre.ToUpper().Contains(filtro.ToUpper()))
                            || (c.Profesional != null && c.Profesional.Nombre != null && c.Profesional.Nombre.ToUpper().Contains(filtro.ToUpper()))
                )
                .ToListAsync();
        }

        // GET: api/Turnos/atendidos
        [HttpGet("atendidos")]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnosAtendidos([FromQuery] string? filtro = "")
        {
            filtro = filtro ?? string.Empty;
            return await _context.Turnos
                .Include(t => t.Paciente)
                .Include(t => t.Profesional)
                .Where(t => t.EstadoTurno == Service.Enums.EstadoTurnoEnum.Atendido &&
                            (
                                (t.Paciente != null && t.Paciente.Nombre != null && t.Paciente.Nombre.ToUpper().Contains(filtro.ToUpper()))
                                || (t.Profesional != null && t.Profesional.Nombre != null && t.Profesional.Nombre.ToUpper().Contains(filtro.ToUpper()))
                            ))
                .ToListAsync();
        }

        // GET: api/Turnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turno>> GetTurno(int id)
        {
            // Incluir las relaciones para obtener datos completos
            var turno = await _context.Turnos
                .Include(t => t.Paciente)
                .Include(t => t.Profesional)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (turno == null)
            {
                return NotFound();
            }

            return turno;
        }

        // PUT: api/Turnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurno(int id, Turno turno)
        {
            if (id != turno.Id)
            {
                return BadRequest();
            }

            _context.Entry(turno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnoExists(id))
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


        // POST: api/Turnos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Turno>> PostPaciente(Turno turno)
        {
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurno", new { id = turno.Id }, turno);
        }

        // DELETE: api/Turnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurno(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            turno.IsDeleted = true;
            _context.Turnos.Update(turno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.Id == id);
        }

    }
}
