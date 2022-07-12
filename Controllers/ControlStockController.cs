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
    public class ControlStockController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public ControlStockController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/ControlStock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ControlStock>>> GetControlStock()
        {
          if (_context.ControlStock == null)
          {
              return NotFound();
          }
            return await _context.ControlStock.ToListAsync();
        }

        // GET: api/ControlStock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ControlStock>> GetControlStock(int id)
        {
          if (_context.ControlStock == null)
          {
              return NotFound();
          }
            var controlStock = await _context.ControlStock.FindAsync(id);

            if (controlStock == null)
            {
                return NotFound();
            }

            return controlStock;
        }

        // PUT: api/ControlStock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControlStock(int id, ControlStock controlStock)
        {
            if (id != controlStock.Id)
            {
                return BadRequest();
            }

            _context.Entry(controlStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControlStockExists(id))
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

        // POST: api/ControlStock
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ControlStock>> PostControlStock(ControlStock controlStock)
        {
          if (_context.ControlStock == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.ControlStock'  is null.");
          }
            _context.ControlStock.Add(controlStock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetControlStock", new { id = controlStock.Id }, controlStock);
        }

        // DELETE: api/ControlStock/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControlStock(int id)
        {
            if (_context.ControlStock == null)
            {
                return NotFound();
            }
            var controlStock = await _context.ControlStock.FindAsync(id);
            if (controlStock == null)
            {
                return NotFound();
            }

            _context.ControlStock.Remove(controlStock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ControlStockExists(int id)
        {
            return (_context.ControlStock?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
