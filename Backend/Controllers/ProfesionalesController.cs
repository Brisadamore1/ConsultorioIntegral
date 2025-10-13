using Backend.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfesionalesController : ControllerBase
    {
        private readonly ConsultorioContext _context;
        public ProfesionalesController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: api/Profesional
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesional>>> GetProfesionales([FromQuery] string? filtro = "")
        {
            return await _context.Profesionales.Include(p => p.Pacientes)
               .Where(c => c.Nombre.ToUpper().Contains(filtro.ToUpper()))
               .ToListAsync();
        }
        [HttpPost("withfilter")]
        public async Task<ActionResult<IEnumerable<Profesional>>> GetProfesionalwithfilter(FilterProfesionalDTO filter)
        {
            var query = _context.Profesionales
                .Include(n => n.Nombre)
                .Include(e => e.Especialidad)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                var search = filter.SearchText.ToLower();
                query = query.Where(l =>
                    (filter.ForNombre && l.Nombre.ToLower().Contains(search)) ||
                    (filter.ForEspecialidad && l.Especialidad.ToLower().Contains(search))
                );
            }

            return await query.ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Profesional>>> GetDeletedsLibros()
        {
            return await _context.Profesionales
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(l => l.Eliminado).ToListAsync();
        }

        // GET: api/Profesional/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesional>> GetProfesional(int id)
        {
            var profesional = await _context.Profesionales.FindAsync(id);

            if (profesional == null)
            {
                return NotFound();
            }

            return profesional;
        }

        // PUT: api/Profesionales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesional(int id, Profesional profesional)
        {
            if (id != profesional.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionalExists(id))
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


        // POST: api/Profesionales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profesional>> PostPaciente(Profesional profesional)
        {
            _context.Profesionales.Add(profesional);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesional", new { id = profesional.Id }, profesional);
        }

        // DELETE: api/Profesionales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesional(int id)
        {
            var profesional = await _context.Profesionales.FindAsync(id);
            if (profesional == null)
            {
                return NotFound();
            }
            profesional.Eliminado = true;
            _context.Profesionales.Update(profesional);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreLibro(int id)
        {
            var profesional = await _context.Profesionales.IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (profesional == null)
            {
                return NotFound();
            }
            profesional.Eliminado = false;
            _context.Profesionales.Update(profesional);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProfesionalExists(int id)
        {
            return _context.Profesionales.Any(e => e.Id == id);
        }

    }
}
