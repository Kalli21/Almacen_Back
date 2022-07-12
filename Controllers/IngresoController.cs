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
    public class IngresoController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public IngresoController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/Ingreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetIngreso()
        {
          if (_context.Ingreso == null)
          {
              return NotFound();
          }
            return await _context.Ingreso.ToListAsync();
        }

        // GET: api/Ingreso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingreso>> GetIngreso(long id)
        {
          if (_context.Ingreso == null)
          {
              return NotFound();
          }
            var ingreso = await _context.Ingreso.FindAsync(id);

            if (ingreso == null)
            {
                return NotFound();
            }

            return ingreso;
        }

        // PUT: api/Ingreso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngreso(long id, Ingreso ingreso)
        {
            if (id != ingreso.id_ingreso)
            {
                return BadRequest();
            }

            _context.Entry(ingreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngresoExists(id))
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

        // POST: api/Ingreso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingreso>> PostIngreso(Ingreso ingreso)
        {
          if (_context.Ingreso == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.Ingreso'  is null.");
          }
            _context.Ingreso.Add(ingreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngreso", new { id = ingreso.id_ingreso }, ingreso);
        }

        // DELETE: api/Ingreso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngreso(long id)
        {
            if (_context.Ingreso == null)
            {
                return NotFound();
            }
            var ingreso = await _context.Ingreso.FindAsync(id);
            if (ingreso == null)
            {
                return NotFound();
            }

            _context.Ingreso.Remove(ingreso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngresoExists(long id)
        {
            return (_context.Ingreso?.Any(e => e.id_ingreso == id)).GetValueOrDefault();
        }
    }
}
