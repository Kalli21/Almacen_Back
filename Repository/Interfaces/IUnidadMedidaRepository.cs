using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IUnidadMedidaRepository
    {
        Task<ICollection<UnidadMedidaDTO>> GetUnidadMedidas();
        Task<UnidadMedidaDTO> GetUnidadMedidaById(string id);
        Task<UnidadMedidaDTO> CreateUnidadMedida(UnidadMedidaDTO unidadMedidaDTO);
        Task<UnidadMedidaDTO> UpdateUnidadMedida(UnidadMedidaDTO unidadMedidaDTO);
        Task<bool> DeleteUnidadMedida(string id);
        
    }
}
