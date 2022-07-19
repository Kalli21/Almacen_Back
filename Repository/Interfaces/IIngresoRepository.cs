using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IIngresoRepository
    {
        Task<ICollection<IngresoDTO>> GetIngresos();
        Task<IngresoDTO> GetIngresoById(long id);
        Task<IngresoDTO> CreateIngreso(IngresoDTO ingresoDTO);
        Task<IngresoDTO> UpdateIngreso(IngresoDTO ingresoDTO);
        Task<bool> DeleteIngreso(long id);
        
    }
}
