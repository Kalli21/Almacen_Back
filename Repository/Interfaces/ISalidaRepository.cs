using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface ISalidaRepository
    {
        Task<ICollection<SalidaDTO>> GetSalidas();
        Task<SalidaDTO> GetSalidaById(long id);
        Task<SalidaDTO> CreateSalida(SalidaDTO salidaDTO);
        Task<SalidaDTO> UpdateSalida(SalidaDTO salidaDTO);
        Task<bool> DeleteSalida(long id);
        
    }
}
