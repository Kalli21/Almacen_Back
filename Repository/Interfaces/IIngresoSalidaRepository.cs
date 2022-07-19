using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IIngresoSalidaRepository
    {
        Task<ICollection<IngresoSalidaDTO>> GetIngresoSalidas();
        Task<IngresoSalidaDTO> GetIngresoSalidaById(long id);
        Task<IngresoSalidaDTO> CreateIngresoSalida(IngresoSalidaDTO ingresoSalidaDTO);
        Task<IngresoSalidaDTO> UpdateIngresoSalida(IngresoSalidaDTO ingresoSalidaDTO);
        Task<bool> DeleteIngresoSalida(long id);
        
    }
}
