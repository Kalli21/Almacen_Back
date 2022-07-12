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
    public class GrupoAccesoController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public GrupoAccesoController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/GrupoAcceso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoAcceso>>> GetGrupoAcceso()
        {
          if (_context.GrupoAcceso == null)
          {
              return NotFound();
          }
            return await _context.GrupoAcceso.ToListAsync();
        }

        // GET: api/GrupoAcceso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoAcceso>> GetGrupoAcceso(string id)
        {
          if (_context.GrupoAcceso == null)
          {
              return NotFound();
          }
            var grupoAcceso = await _context.GrupoAcceso.FindAsync(id);

            if (grupoAcceso == null)
            {
                return NotFound();
            }

            return grupoAcceso;
        }

        // PUT: api/GrupoAcceso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoAcceso(string id, GrupoAcceso grupoAcceso)
        {
            if (id != grupoAcceso.Cod_grupo)
            {
                return BadRequest();
            }

            _context.Entry(grupoAcceso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoAccesoExists(id))
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

        // POST: api/GrupoAcceso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoAcceso>> PostGrupoAcceso(GrupoAcceso grupoAcceso)
        {
          if (_context.GrupoAcceso == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.GrupoAcceso'  is null.");
          }
            _context.GrupoAcceso.Add(grupoAcceso);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GrupoAccesoExists(grupoAcceso.Cod_grupo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGrupoAcceso", new { id = grupoAcceso.Cod_grupo }, grupoAcceso);
        }

        // DELETE: api/GrupoAcceso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoAcceso(string id)
        {
            if (_context.GrupoAcceso == null)
            {
                return NotFound();
            }
            var grupoAcceso = await _context.GrupoAcceso.FindAsync(id);
            if (grupoAcceso == null)
            {
                return NotFound();
            }

            _context.GrupoAcceso.Remove(grupoAcceso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoAccesoExists(string id)
        {
            return (_context.GrupoAcceso?.Any(e => e.Cod_grupo == id)).GetValueOrDefault();
        }
    }
}
