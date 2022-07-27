using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetPedidoController : ControllerBase
    {
        private readonly IDetPedidoService _detPedidoService;

        public DetPedidoController(IDetPedidoService detPedidoService)
        {
            _detPedidoService = detPedidoService;
        }

        // GET: api/DetPedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetPedidoDTO>>> GetDetPedido()
        {
            return await _detPedidoService.GetDetPedidos();
        }

        // GET: api/DetPedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetPedidoDTO>> GetDetPedido(int id)
        {
            return await _detPedidoService.GetDetPedidoById(id);
        }

        // PUT: api/DetPedido/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetPedido(int id, DetPedidoDTO detPedidoDTO)
        {
            return await _detPedidoService.UpdateDetPedido(id, detPedidoDTO);
        }

        // POST: api/DetPedido
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetPedidoDTO>> PostDetPedido(DetPedidoDTO detPedidoDTO)
        {
            return await _detPedidoService.CreateDetPedido(detPedidoDTO);
        }

        // DELETE: api/DetPedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetPedido(int id)
        {
            return await _detPedidoService.DeleteDetPedido(id);
        }

    }
}
