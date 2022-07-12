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
    public class ArticuloController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public ArticuloController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/Articulo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulo()
        {
          if (_context.Articulo == null)
          {
              return NotFound();
          }
            return await _context.Articulo.ToListAsync();
        }

        // GET: api/Articulo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(long id)
        {
          if (_context.Articulo == null)
          {
              return NotFound();
          }
            var articulo = await _context.Articulo.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/Articulo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(long id, Articulo articulo)
        {
            if (id != articulo.cod_articulo)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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

        // POST: api/Articulo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
          if (_context.Articulo == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.Articulo'  is null.");
          }
            _context.Articulo.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.cod_articulo }, articulo);
        }

        // DELETE: api/Articulo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(long id)
        {
            if (_context.Articulo == null)
            {
                return NotFound();
            }
            var articulo = await _context.Articulo.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulo.Remove(articulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticuloExists(long id)
        {
            return (_context.Articulo?.Any(e => e.cod_articulo == id)).GetValueOrDefault();
        }
    }
}
