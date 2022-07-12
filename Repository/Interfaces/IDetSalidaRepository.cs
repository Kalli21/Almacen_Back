using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IDetSalidaRepository
    {
        Task<ICollection<DetSalidaDTO>> GetDetSalidas();
        Task<DetSalidaDTO> GetDetSalidaById(string id);
        Task<DetSalidaDTO> CreateDetSalida(DetSalidaDTO detSalidaDTO);
        Task<DetSalidaDTO> UpdateDetSalida(DetSalidaDTO detSalidaDTO);
        Task<bool> DeleteDetSalida(string id);
        
    }
}
