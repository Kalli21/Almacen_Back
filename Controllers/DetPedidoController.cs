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
    public class DetPedidoController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public DetPedidoController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/DetPedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetPedido>>> GetDetPedido()
        {
          if (_context.DetPedido == null)
          {
              return NotFound();
          }
            return await _context.DetPedido.ToListAsync();
        }

        // GET: api/DetPedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetPedido>> GetDetPedido(int id)
        {
          if (_context.DetPedido == null)
          {
              return NotFound();
          }
            var detPedido = await _context.DetPedido.FindAsync(id);

            if (detPedido == null)
            {
                return NotFound();
            }

            return detPedido;
        }

        // PUT: api/DetPedido/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetPedido(int id, DetPedido detPedido)
        {
            if (id != detPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(detPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetPedidoExists(id))
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

        // POST: api/DetPedido
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetPedido>> PostDetPedido(DetPedido detPedido)
        {
          if (_context.DetPedido == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.DetPedido'  is null.");
          }
            _context.DetPedido.Add(detPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetPedido", new { id = detPedido.Id }, detPedido);
        }

        // DELETE: api/DetPedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetPedido(int id)
        {
            if (_context.DetPedido == null)
            {
                return NotFound();
            }
            var detPedido = await _context.DetPedido.FindAsync(id);
            if (detPedido == null)
            {
                return NotFound();
            }

            _context.DetPedido.Remove(detPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetPedidoExists(int id)
        {
            return (_context.DetPedido?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
