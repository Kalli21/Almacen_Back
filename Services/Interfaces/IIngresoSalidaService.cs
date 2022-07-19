using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IIngresoSalidaService
    {
        Task<ActionResult<IEnumerable<IngresoSalidaDTO>>> GetIngresoSalidas();
        Task<ActionResult<IngresoSalidaDTO>> GetIngresoSalidaById(long id);
        Task<ActionResult<IngresoSalidaDTO>> CreateIngresoSalida(IngresoSalidaDTO ingresoSalidaDTO);
        Task<IActionResult> UpdateIngresoSalida(long id , IngresoSalidaDTO ingresoSalidaDTO);
        Task<IActionResult> DeleteIngresoSalida(long id);
        
    }
}
