using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IProveedorService
    {
        Task<ActionResult<IEnumerable<ProveedorDTO>>> GetProveedores();
        Task<ActionResult<ProveedorDTO>> GetProveedorById(string id);
        Task<ActionResult<ProveedorDTO>> CreateProveedor(ProveedorDTO proveedorDTO);
        Task<IActionResult> UpdateProveedor(string id , ProveedorDTO proveedorDTO);
        Task<IActionResult> DeleteProveedor(string id);
        
    }
}
