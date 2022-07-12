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
    public class UnidadMedidaController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public UnidadMedidaController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/UnidadMedida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadMedida>>> GetUnidadMedida()
        {
          if (_context.UnidadMedida == null)
          {
              return NotFound();
          }
            return await _context.UnidadMedida.ToListAsync();
        }

        // GET: api/UnidadMedida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadMedida>> GetUnidadMedida(string id)
        {
          if (_context.UnidadMedida == null)
          {
              return NotFound();
          }
            var unidadMedida = await _context.UnidadMedida.FindAsync(id);

            if (unidadMedida == null)
            {
                return NotFound();
            }

            return unidadMedida;
        }

        // PUT: api/UnidadMedida/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadMedida(string id, UnidadMedida unidadMedida)
        {
            if (id != unidadMedida.cod_und_medida)
            {
                return BadRequest();
            }

            _context.Entry(unidadMedida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadMedidaExists(id))
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

        // POST: api/UnidadMedida
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnidadMedida>> PostUnidadMedida(UnidadMedida unidadMedida)
        {
          if (_context.UnidadMedida == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.UnidadMedida'  is null.");
          }
            _context.UnidadMedida.Add(unidadMedida);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnidadMedidaExists(unidadMedida.cod_und_medida))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnidadMedida", new { id = unidadMedida.cod_und_medida }, unidadMedida);
        }

        // DELETE: api/UnidadMedida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadMedida(string id)
        {
            if (_context.UnidadMedida == null)
            {
                return NotFound();
            }
            var unidadMedida = await _context.UnidadMedida.FindAsync(id);
            if (unidadMedida == null)
            {
                return NotFound();
            }

            _context.UnidadMedida.Remove(unidadMedida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadMedidaExists(string id)
        {
            return (_context.UnidadMedida?.Any(e => e.cod_und_medida == id)).GetValueOrDefault();
        }
    }
}
