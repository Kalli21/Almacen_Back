using Almacen_Back.Models.DTO;
using Almacen_Back.Models.Request;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IPedidoRepository
    {
        Task<(decimal ,ICollection<PedidoDTO>)> GetPedidos(long? codClave,int page, PedidosFiltros filtros);
        Task<PedidoDTO> GetPedidoById(long id);
        Task<PedidoDTO> CreatePedido(PedidoDTO pedidoDTO);
        Task<PedidoDTO> UpdatePedido(PedidoDTO pedidoDTO);
        Task<bool> DeletePedido(long id);
        
    }
}
