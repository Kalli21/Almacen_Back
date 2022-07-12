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
    public class DetIngresoSalidaController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public DetIngresoSalidaController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/DetIngresoSalida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetIngresoSalida>>> GetDetIngresoSalida()
        {
          if (_context.DetIngresoSalida == null)
          {
              return NotFound();
          }
            return await _context.DetIngresoSalida.ToListAsync();
        }

        // GET: api/DetIngresoSalida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetIngresoSalida>> GetDetIngresoSalida(int id)
        {
          if (_context.DetIngresoSalida == null)
          {
              return NotFound();
          }
            var detIngresoSalida = await _context.DetIngresoSalida.FindAsync(id);

            if (detIngresoSalida == null)
            {
                return NotFound();
            }

            return detIngresoSalida;
        }

        // PUT: api/DetIngresoSalida/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetIngresoSalida(int id, DetIngresoSalida detIngresoSalida)
        {
            if (id != detIngresoSalida.Id)
            {
                return BadRequest();
            }

            _context.Entry(detIngresoSalida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetIngresoSalidaExists(id))
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

        // POST: api/DetIngresoSalida
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetIngresoSalida>> PostDetIngresoSalida(DetIngresoSalida detIngresoSalida)
        {
          if (_context.DetIngresoSalida == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.DetIngresoSalida'  is null.");
          }
            _context.DetIngresoSalida.Add(detIngresoSalida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetIngresoSalida", new { id = detIngresoSalida.Id }, detIngresoSalida);
        }

        // DELETE: api/DetIngresoSalida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetIngresoSalida(int id)
        {
            if (_context.DetIngresoSalida == null)
            {
                return NotFound();
            }
            var detIngresoSalida = await _context.DetIngresoSalida.FindAsync(id);
            if (detIngresoSalida == null)
            {
                return NotFound();
            }

            _context.DetIngresoSalida.Remove(detIngresoSalida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetIngresoSalidaExists(int id)
        {
            return (_context.DetIngresoSalida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
