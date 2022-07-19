using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IPedidoRepository
    {
        Task<ICollection<PedidoDTO>> GetPedidos();
        Task<PedidoDTO> GetPedidoById(long id);
        Task<PedidoDTO> CreatePedido(PedidoDTO pedidoDTO);
        Task<PedidoDTO> UpdatePedido(PedidoDTO pedidoDTO);
        Task<bool> DeletePedido(long id);
        
    }
}
