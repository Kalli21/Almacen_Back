using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IProveedorRepository
    {
        Task<ICollection<ProveedorDTO>> GetProveedores();
        Task<ProveedorDTO> GetProveedorById(string id);
        Task<ProveedorDTO> CreateProveedor(ProveedorDTO proveedorDTO);
        Task<ProveedorDTO> UpdateProveedor(ProveedorDTO proveedorDTO);
        Task<bool> DeleteProveedor(string id);
        
    }
}
