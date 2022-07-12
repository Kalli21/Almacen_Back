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
    public class DetIngresoController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public DetIngresoController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/DetIngreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetIngreso>>> GetDetIngreso()
        {
          if (_context.DetIngreso == null)
          {
              return NotFound();
          }
            return await _context.DetIngreso.ToListAsync();
        }

        // GET: api/DetIngreso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetIngreso>> GetDetIngreso(int id)
        {
          if (_context.DetIngreso == null)
          {
              return NotFound();
          }
            var detIngreso = await _context.DetIngreso.FindAsync(id);

            if (detIngreso == null)
            {
                return NotFound();
            }

            return detIngreso;
        }

        // PUT: api/DetIngreso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetIngreso(int id, DetIngreso detIngreso)
        {
            if (id != detIngreso.Id)
            {
                return BadRequest();
            }

            _context.Entry(detIngreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetIngresoExists(id))
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

        // POST: api/DetIngreso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetIngreso>> PostDetIngreso(DetIngreso detIngreso)
        {
          if (_context.DetIngreso == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.DetIngreso'  is null.");
          }
            _context.DetIngreso.Add(detIngreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetIngreso", new { id = detIngreso.Id }, detIngreso);
        }

        // DELETE: api/DetIngreso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetIngreso(int id)
        {
            if (_context.DetIngreso == null)
            {
                return NotFound();
            }
            var detIngreso = await _context.DetIngreso.FindAsync(id);
            if (detIngreso == null)
            {
                return NotFound();
            }

            _context.DetIngreso.Remove(detIngreso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetIngresoExists(int id)
        {
            return (_context.DetIngreso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
