using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> GetPedido()
        {
            return await _pedidoService.GetPedidos();
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDTO>> GetPedido(long id)
        {
            return await _pedidoService.GetPedidoById(id);
        }

        // PUT: api/Pedido/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(long id, PedidoDTO pedidoDTO)
        {
            return await _pedidoService.UpdatePedido(id,pedidoDTO);
        }

        // POST: api/Pedido
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PedidoDTO>> PostPedido(PedidoDTO pedidoDTO)
        {
            return await _pedidoService.CreatePedido(pedidoDTO);
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(long id)
        {
            return await _pedidoService.DeletePedido(id);
        }

    }
}
