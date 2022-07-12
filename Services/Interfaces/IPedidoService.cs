using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<ActionResult<IEnumerable<PedidoDTO>>> GetPedidos();
        Task<ActionResult<PedidoDTO>> GetPedidoById(string id);
        Task<ActionResult<PedidoDTO>> CreatePedido(PedidoDTO pedidoDTO);
        Task<IActionResult> UpdatePedido(string id , PedidoDTO pedidoDTO);
        Task<IActionResult> DeletePedido(string id);
        
    }
}
