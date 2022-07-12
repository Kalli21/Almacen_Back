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
    public class TipoTransaccionController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public TipoTransaccionController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/TipoTransaccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTransaccion>>> GetTipoTransaccion()
        {
          if (_context.TipoTransaccion == null)
          {
              return NotFound();
          }
            return await _context.TipoTransaccion.ToListAsync();
        }

        // GET: api/TipoTransaccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTransaccion>> GetTipoTransaccion(string id)
        {
          if (_context.TipoTransaccion == null)
          {
              return NotFound();
          }
            var tipoTransaccion = await _context.TipoTransaccion.FindAsync(id);

            if (tipoTransaccion == null)
            {
                return NotFound();
            }

            return tipoTransaccion;
        }

        // PUT: api/TipoTransaccion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTransaccion(string id, TipoTransaccion tipoTransaccion)
        {
            if (id != tipoTransaccion.cod_tipo_transaccion)
            {
                return BadRequest();
            }

            _context.Entry(tipoTransaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTransaccionExists(id))
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

        // POST: api/TipoTransaccion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoTransaccion>> PostTipoTransaccion(TipoTransaccion tipoTransaccion)
        {
          if (_context.TipoTransaccion == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.TipoTransaccion'  is null.");
          }
            _context.TipoTransaccion.Add(tipoTransaccion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoTransaccionExists(tipoTransaccion.cod_tipo_transaccion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoTransaccion", new { id = tipoTransaccion.cod_tipo_transaccion }, tipoTransaccion);
        }

        // DELETE: api/TipoTransaccion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTransaccion(string id)
        {
            if (_context.TipoTransaccion == null)
            {
                return NotFound();
            }
            var tipoTransaccion = await _context.TipoTransaccion.FindAsync(id);
            if (tipoTransaccion == null)
            {
                return NotFound();
            }

            _context.TipoTransaccion.Remove(tipoTransaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoTransaccionExists(string id)
        {
            return (_context.TipoTransaccion?.Any(e => e.cod_tipo_transaccion == id)).GetValueOrDefault();
        }
    }
}
