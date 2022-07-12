using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface ISalidaService
    {
        Task<ActionResult<IEnumerable<SalidaDTO>>> GetSalidas();
        Task<ActionResult<SalidaDTO>> GetSalidaById(string id);
        Task<ActionResult<SalidaDTO>> CreateSalida(SalidaDTO salidaDTO);
        Task<IActionResult> UpdateSalida(string id , SalidaDTO salidaDTO);
        Task<IActionResult> DeleteSalida(string id);
        
    }
}
