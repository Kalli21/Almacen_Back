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
    public class PedidoController : ControllerBase
    {
        private readonly Almacen_Back_Context _context;

        public PedidoController(Almacen_Back_Context context)
        {
            _context = context;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
        {
          if (_context.Pedido == null)
          {
              return NotFound();
          }
            return await _context.Pedido.ToListAsync();
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(long id)
        {
          if (_context.Pedido == null)
          {
              return NotFound();
          }
            var pedido = await _context.Pedido.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedido/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(long id, Pedido pedido)
        {
            if (id != pedido.id_pedido)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedido
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
          if (_context.Pedido == null)
          {
              return Problem("Entity set 'Almacen_Back_Context.Pedido'  is null.");
          }
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.id_pedido }, pedido);
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(long id)
        {
            if (_context.Pedido == null)
            {
                return NotFound();
            }
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(long id)
        {
            return (_context.Pedido?.Any(e => e.id_pedido == id)).GetValueOrDefault();
        }
    }
}
