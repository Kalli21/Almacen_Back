using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IIngresoService
    {
        Task<ActionResult<IEnumerable<IngresoDTO>>> GetIngresos();
        Task<ActionResult<IngresoDTO>> GetIngresoById(string id);
        Task<ActionResult<IngresoDTO>> CreateIngreso(IngresoDTO ingresoDTO);
        Task<IActionResult> UpdateIngreso(string id , IngresoDTO ingresoDTO);
        Task<IActionResult> DeleteIngreso(string id);
        
    }
}
