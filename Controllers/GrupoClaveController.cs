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
    public class GrupoClaveController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public GrupoClaveController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/GrupoClave
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoClave>>> GetGrupoClave()
        {
          if (_context.GrupoClave == null)
          {
              return NotFound();
          }
            return await _context.GrupoClave.ToListAsync();
        }

        // GET: api/GrupoClave/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoClave>> GetGrupoClave(long id)
        {
          if (_context.GrupoClave == null)
          {
              return NotFound();
          }
            var grupoClave = await _context.GrupoClave.FindAsync(id);

            if (grupoClave == null)
            {
                return NotFound();
            }

            return grupoClave;
        }

        // PUT: api/GrupoClave/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoClave(long id, GrupoClave grupoClave)
        {
            if (id != grupoClave.cod_clave)
            {
                return BadRequest();
            }

            _context.Entry(grupoClave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoClaveExists(id))
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

        // POST: api/GrupoClave
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoClave>> PostGrupoClave(GrupoClave grupoClave)
        {
          if (_context.GrupoClave == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.GrupoClave'  is null.");
          }
            _context.GrupoClave.Add(grupoClave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoClave", new { id = grupoClave.cod_clave }, grupoClave);
        }

        // DELETE: api/GrupoClave/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoClave(long id)
        {
            if (_context.GrupoClave == null)
            {
                return NotFound();
            }
            var grupoClave = await _context.GrupoClave.FindAsync(id);
            if (grupoClave == null)
            {
                return NotFound();
            }

            _context.GrupoClave.Remove(grupoClave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoClaveExists(long id)
        {
            return (_context.GrupoClave?.Any(e => e.cod_clave == id)).GetValueOrDefault();
        }
    }
}
