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
    public class SesionesController : ControllerBase
    {
        private readonly ConsultorioContext _context;
        public SesionesController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: api/Profesionales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sesion>>> GetSesiones([FromQuery] string? filtro = "")
        {
            return await _context.Sesiones
               .Where(c => c.Notas.ToUpper().Contains(filtro.ToUpper()))
               .ToListAsync();
        }

        // GET: api/Sesiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sesion>> GetSesion(int id)
        {
            var sesion = await _context.Sesiones.FindAsync(id);

            if (sesion == null)
            {
                return NotFound();
            }

            return sesion;
        }

        // PUT: api/Sesiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSesion(int id, Sesion sesion)
        {
            if (id != sesion.Id)
            {
                return BadRequest();
            }

            _context.Entry(sesion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SesionExists(id))
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

        // POST: api/Sesiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sesion>> PostSesion(Sesion sesion)
        {
            _context.Sesiones.Add(sesion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSesion", new { id = sesion.Id }, sesion);
        }

        // DELETE: api/Sesiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesion(int id)
        {
            var sesion = await _context.Sesiones.FindAsync(id);
            if (sesion == null)
            {
                return NotFound();
            }
            sesion.IsDeleted = true;
            _context.Sesiones.Update(sesion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool SesionExists(int id)
        {
            return _context.Deudas.Any(e => e.Id == id);
        }
    }
}
