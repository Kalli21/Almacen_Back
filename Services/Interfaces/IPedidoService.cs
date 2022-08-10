using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<ActionResult<IEnumerable<PedidoDTO>>> GetPedidos(int ? page);
        Task<ActionResult<PedidoDTO>> GetPedidoById(long id);
        Task<ActionResult<PedidoDTO>> CreatePedido(PedidoDTO pedidoDTO);
        Task<IActionResult> UpdatePedido(long id , PedidoDTO pedidoDTO);
        Task<IActionResult> DeletePedido(long id);
        
    }
}
