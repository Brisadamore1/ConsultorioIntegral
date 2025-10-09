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
    public class ContactosEmergenciaController : ControllerBase
    {
        private readonly ConsultorioContext _context;

        public ContactosEmergenciaController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: api/ContactoEmergencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactoEmergencia>>> GetContactosEmergencia([FromQuery] string? filtro = "")
        {
            return await _context.ContactosEmergencia
               .AsNoTracking()
               .Include(c => c.Paciente)
               .Where(c => c.Nombre.ToUpper().Contains(filtro.ToUpper()))
               .ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<ContactoEmergencia>>> GetDeletedsContactosEmergencia()
        {
            return await _context.ContactosEmergencia
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(c => c.Eliminado).ToListAsync();
        }

        // GET: api/ContactoEmergencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactoEmergencia>> GetContactoEmergencia(int id)
        {
            var contactoEmergencia = await _context.ContactosEmergencia.AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(id));

            if (contactoEmergencia == null)
            {
                return NotFound();
            }

            return contactoEmergencia;  
        }

        // PUT: api/ContactoEmergencia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactoEmergencia(int? id, ContactoEmergencia contactoEmergencia)
        {
            if (id == null)
            {   
                return BadRequest();
            }
            if (contactoEmergencia == null)
            {
                throw new ArgumentNullException();
            }
            if (id != contactoEmergencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactoEmergencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoEmergenciaExists(id))
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
        public async Task<ActionResult<ContactoEmergencia>> PostContactoEmergencia (ContactoEmergencia contactoEmergencia)
        {
            _context.ContactosEmergencia.Add(contactoEmergencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactoEmergencia", new { id = contactoEmergencia.Id }, contactoEmergencia);
        }

        // DELETE: api/ContactosEmergencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactoEmergencia(int id)
        {
            var contactoEmergencia = await _context.ContactosEmergencia.FindAsync(id);
            if (contactoEmergencia == null)
            {
                return NotFound();
            }
            contactoEmergencia.Eliminado = true;
            _context.ContactosEmergencia.Update(contactoEmergencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreContactoEmergencia(int id)
        {
            var contactoEmergencia = await _context.ContactosEmergencia.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (contactoEmergencia == null)
            {
                return NotFound();
            }
            contactoEmergencia.Eliminado = false;
            //Impacta en memoria
            _context.ContactosEmergencia.Update(contactoEmergencia);
            //Aca recien impacta en la base de datos
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ContactoEmergenciaExists(int? id)
        {
            return _context.ContactosEmergencia.Any(e => e.Id == id);
        }
    }
}
