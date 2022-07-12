using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IDetIngresoSalidaService
    {
        Task<ActionResult<IEnumerable<DetIngresoSalidaDTO>>> GetDetIngresoSalidas();
        Task<ActionResult<DetIngresoSalidaDTO>> GetDetIngresoSalidaById(string id);
        Task<ActionResult<DetIngresoSalidaDTO>> CreateDetIngresoSalida(DetIngresoSalidaDTO detIngresoSalidaDTO);
        Task<IActionResult> UpdateDetIngresoSalida(string id , DetIngresoSalidaDTO detIngresoSalidaDTO);
        Task<IActionResult> DeleteDetIngresoSalida(string id);
        
    }
}
