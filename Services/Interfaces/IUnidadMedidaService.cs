using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IUnidadMedidaService
    {
        Task<ActionResult<IEnumerable<UnidadMedidaDTO>>> GetUnidadMedidas();
        Task<ActionResult<UnidadMedidaDTO>> GetUnidadMedidaById(string id);
        Task<ActionResult<UnidadMedidaDTO>> CreateUnidadMedida(UnidadMedidaDTO unidadMedidaDTO);
        Task<IActionResult> UpdateUnidadMedida(string id , UnidadMedidaDTO unidadMedidaDTO);
        Task<IActionResult> DeleteUnidadMedida(string id);
        
    }
}
