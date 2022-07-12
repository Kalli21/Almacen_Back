using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Almacen_Back.Data;
using Almacen_Back.Models;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetSalidaController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public DetSalidaController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/DetSalida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetSalida>>> GetDetSalida()
        {
          if (_context.DetSalida == null)
          {
              return NotFound();
          }
            return await _context.DetSalida.ToListAsync();
        }

        // GET: api/DetSalida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetSalida>> GetDetSalida(int id)
        {
          if (_context.DetSalida == null)
          {
              return NotFound();
          }
            var detSalida = await _context.DetSalida.FindAsync(id);

            if (detSalida == null)
            {
                return NotFound();
            }

            return detSalida;
        }

        // PUT: api/DetSalida/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetSalida(int id, DetSalida detSalida)
        {
            if (id != detSalida.Id)
            {
                return BadRequest();
            }

            _context.Entry(detSalida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetSalidaExists(id))
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

        // POST: api/DetSalida
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetSalida>> PostDetSalida(DetSalida detSalida)
        {
          if (_context.DetSalida == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.DetSalida'  is null.");
          }
            _context.DetSalida.Add(detSalida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetSalida", new { id = detSalida.Id }, detSalida);
        }

        // DELETE: api/DetSalida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetSalida(int id)
        {
            if (_context.DetSalida == null)
            {
                return NotFound();
            }
            var detSalida = await _context.DetSalida.FindAsync(id);
            if (detSalida == null)
            {
                return NotFound();
            }

            _context.DetSalida.Remove(detSalida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetSalidaExists(int id)
        {
            return (_context.DetSalida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
