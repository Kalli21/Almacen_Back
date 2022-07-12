using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IAlmacenRepository
    {
        Task<ICollection<AlmacenDTO>> GetAlmacenes();
        Task<AlmacenDTO> GetAlmacenById(string id);
        Task<AlmacenDTO> CreateAlmacen(AlmacenDTO almacenDTO);
        Task<AlmacenDTO> UpdateAlmacen(AlmacenDTO almacenDTO);
        Task<bool> DeleteAlmacen(string id);
        
    }
}
