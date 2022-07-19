using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IDetIngresoRepository
    {
        Task<ICollection<DetIngresoDTO>> GetDetIngresos();
        Task<DetIngresoDTO> GetDetIngresoById(long id);
        Task<DetIngresoDTO> CreateDetIngreso(DetIngresoDTO detIngresoDTO);
        Task<DetIngresoDTO> UpdateDetIngreso(DetIngresoDTO detIngresoDTO);
        Task<bool> DeleteDetIngreso(long id);
        
    }
}
