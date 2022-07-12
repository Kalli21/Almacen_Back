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
    public class IngresoSalidaController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public IngresoSalidaController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/IngresoSalida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngresoSalida>>> GetIngresoSalida()
        {
          if (_context.IngresoSalida == null)
          {
              return NotFound();
          }
            return await _context.IngresoSalida.ToListAsync();
        }

        // GET: api/IngresoSalida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngresoSalida>> GetIngresoSalida(long id)
        {
          if (_context.IngresoSalida == null)
          {
              return NotFound();
          }
            var ingresoSalida = await _context.IngresoSalida.FindAsync(id);

            if (ingresoSalida == null)
            {
                return NotFound();
            }

            return ingresoSalida;
        }

        // PUT: api/IngresoSalida/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngresoSalida(long id, IngresoSalida ingresoSalida)
        {
            if (id != ingresoSalida.id_transaccion)
            {
                return BadRequest();
            }

            _context.Entry(ingresoSalida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngresoSalidaExists(id))
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

        // POST: api/IngresoSalida
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngresoSalida>> PostIngresoSalida(IngresoSalida ingresoSalida)
        {
          if (_context.IngresoSalida == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.IngresoSalida'  is null.");
          }
            _context.IngresoSalida.Add(ingresoSalida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngresoSalida", new { id = ingresoSalida.id_transaccion }, ingresoSalida);
        }

        // DELETE: api/IngresoSalida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngresoSalida(long id)
        {
            if (_context.IngresoSalida == null)
            {
                return NotFound();
            }
            var ingresoSalida = await _context.IngresoSalida.FindAsync(id);
            if (ingresoSalida == null)
            {
                return NotFound();
            }

            _context.IngresoSalida.Remove(ingresoSalida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngresoSalidaExists(long id)
        {
            return (_context.IngresoSalida?.Any(e => e.id_transaccion == id)).GetValueOrDefault();
        }
    }
}
