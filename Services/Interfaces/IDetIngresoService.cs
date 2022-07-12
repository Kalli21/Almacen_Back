using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IDetIngresoService
    {
        Task<ActionResult<IEnumerable<DetIngresoDTO>>> GetDetIngresos();
        Task<ActionResult<DetIngresoDTO>> GetDetIngresoById(string id);
        Task<ActionResult<DetIngresoDTO>> CreateDetIngreso(DetIngresoDTO detIngresoDTO);
        Task<IActionResult> UpdateDetIngreso(string id , DetIngresoDTO detIngresoDTO);
        Task<IActionResult> DeleteDetIngreso(string id);
        
    }
}
