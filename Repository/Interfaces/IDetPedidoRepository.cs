using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IDetPedidoRepository
    {
        Task<ICollection<DetPedidoDTO>> GetDetPedidos();
        Task<DetPedidoDTO> GetDetPedidoById(long id);
        Task<DetPedidoDTO> CreateDetPedido(DetPedidoDTO detPedidoDTO);
        Task<DetPedidoDTO> UpdateDetPedido(DetPedidoDTO detPedidoDTO);
        Task<bool> DeleteDetPedido(long id);
        
    }
}
