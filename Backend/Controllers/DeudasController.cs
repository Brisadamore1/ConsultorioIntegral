using Backend.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Models;
using System.ComponentModel;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DeudasController : ControllerBase
    {
        private readonly ConsultorioContext _context;
        public DeudasController(ConsultorioContext context)
        {
            _context = context;
        }

        // GET: api/Deuda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deuda>>> GetDeudas([FromQuery] string? filtro = "")
        {
            return await _context.Deudas
               .AsNoTracking()
               .Include(c => c.Paciente)
               .Where(c => c.Paciente.Nombre.ToUpper().Contains(filtro.ToUpper()))
               .ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Deuda>>> GetDeletedsDeudas()
        {
            return await _context.Deudas
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(a => a.IsDeleted).ToListAsync();
        }
        // GET: api/Deuda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deuda>> GetDeuda(int id)
        {
            var deuda = await _context.Deudas.AsNoTracking().FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (deuda == null)
            {
                return NotFound();
            }

            return deuda;
        }

        // PUT: api/Deudas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeuda(int id, Deuda deuda)
        {
            if (id != deuda.Id)
            {
                return BadRequest();
            }

            _context.Entry(deuda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeudaExists(id))
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

        // POST: api/Deudas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deuda>> PostDeuda(Deuda deuda)
        {
            _context.Deudas.Add(deuda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeuda", new { id = deuda.Id }, deuda);
        }

        // DELETE: api/Deudas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeuda(int id)
        {
            var deuda = await _context.Deudas.FindAsync(id);
            if (deuda == null)
            {
                return NotFound();
            }
            deuda.IsDeleted = true;
            _context.Deudas.Update(deuda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreDeuda(int id)
        {
            var deuda = await _context.Deudas.IgnoreQueryFilters().FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (deuda == null)
            {
                return NotFound();
            }
            deuda.IsDeleted = false;
            //Impacta en memoria
            _context.Deudas.Update(deuda);
            //Aca recien impacta en la base de datos
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool DeudaExists(int id)
        {
            return _context.Deudas.Any(e => e.Id == id);
        }
    }
}
