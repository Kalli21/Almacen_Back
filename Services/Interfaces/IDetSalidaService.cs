using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IDetSalidaService
    {
        Task<ActionResult<IEnumerable<DetSalidaDTO>>> GetDetSalidas();
        Task<ActionResult<DetSalidaDTO>> GetDetSalidaById(string id);
        Task<ActionResult<DetSalidaDTO>> CreateDetSalida(DetSalidaDTO detSalidaDTO);
        Task<IActionResult> UpdateDetSalida(string id , DetSalidaDTO detSalidaDTO);
        Task<IActionResult> DeleteDetSalida(string id);
        
    }
}
