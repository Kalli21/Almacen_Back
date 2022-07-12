using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface ITipoTransaccionService
    {
        Task<ActionResult<IEnumerable<TipoTransaccionDTO>>> GetTipoTransaccions();
        Task<ActionResult<TipoTransaccionDTO>> GetTipoTransaccionById(string id);
        Task<ActionResult<TipoTransaccionDTO>> CreateTipoTransaccion(TipoTransaccionDTO tipoTransaccionDTO);
        Task<IActionResult> UpdateTipoTransaccion(string id , TipoTransaccionDTO tipoTransaccionDTO);
        Task<IActionResult> DeleteTipoTransaccion(string id);
        
    }
}
