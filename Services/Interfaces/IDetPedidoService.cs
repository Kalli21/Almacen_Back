using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IDetPedidoService
    {
        Task<ActionResult<IEnumerable<DetPedidoDTO>>> GetDetPedidos();
        Task<ActionResult<DetPedidoDTO>> GetDetPedidoById(long id);
        Task<ActionResult<DetPedidoDTO>> CreateDetPedido(DetPedidoDTO detPedidoDTO);
        Task<IActionResult> UpdateDetPedido(long id , DetPedidoDTO detPedidoDTO);
        Task<IActionResult> DeleteDetPedido(long id);
        
    }
}
