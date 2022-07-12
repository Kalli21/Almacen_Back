using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IDetIngresoSalidaRepository
    {
        Task<ICollection<DetIngresoSalidaDTO>> GetDetIngresoSalidas();
        Task<DetIngresoSalidaDTO> GetDetIngresoSalidaById(string id);
        Task<DetIngresoSalidaDTO> CreateDetIngresoSalida(DetIngresoSalidaDTO detIngresoSalidaDTO);
        Task<DetIngresoSalidaDTO> UpdateDetIngresoSalida(DetIngresoSalidaDTO detIngresoSalidaDTO);
        Task<bool> DeleteDetIngresoSalida(string id);
        
    }
}
