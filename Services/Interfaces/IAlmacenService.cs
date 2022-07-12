using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IAlmacenService
    {
        Task<ActionResult<IEnumerable<AlmacenDTO>>> GetAlmacenes();
        Task<ActionResult<AlmacenDTO>> GetAlmacenById(string id);
        Task<ActionResult<AlmacenDTO>> CreateAlmacen(AlmacenDTO almacenDTO);
        Task<IActionResult> UpdateAlmacen(string id,AlmacenDTO almacenDTO);
        Task<IActionResult> DeleteAlmacen(string id);
    }
}
