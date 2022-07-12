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
    public class SalidaController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public SalidaController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/Salidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salida>>> GetSalida()
        {
          if (_context.Salida == null)
          {
              return NotFound();
          }
            return await _context.Salida.ToListAsync();
        }

        // GET: api/Salidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salida>> GetSalida(long id)
        {
          if (_context.Salida == null)
          {
              return NotFound();
          }
            var salida = await _context.Salida.FindAsync(id);

            if (salida == null)
            {
                return NotFound();
            }

            return salida;
        }

        // PUT: api/Salidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalida(long id, Salida salida)
        {
            if (id != salida.id_salida)
            {
                return BadRequest();
            }

            _context.Entry(salida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalidaExists(id))
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

        // POST: api/Salidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salida>> PostSalida(Salida salida)
        {
          if (_context.Salida == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.Salida'  is null.");
          }
            _context.Salida.Add(salida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalida", new { id = salida.id_salida }, salida);
        }

        // DELETE: api/Salidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalida(long id)
        {
            if (_context.Salida == null)
            {
                return NotFound();
            }
            var salida = await _context.Salida.FindAsync(id);
            if (salida == null)
            {
                return NotFound();
            }

            _context.Salida.Remove(salida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalidaExists(long id)
        {
            return (_context.Salida?.Any(e => e.id_salida == id)).GetValueOrDefault();
        }
    }
}
