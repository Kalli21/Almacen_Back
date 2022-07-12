using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IGrupoClaveService
    {
        Task<ActionResult<IEnumerable<GrupoClaveDTO>>> GetGrupoClaves();
        Task<ActionResult<GrupoClaveDTO>> GetGrupoClaveById(string id);
        Task<ActionResult<GrupoClaveDTO>> CreateGrupoClave(GrupoClaveDTO grupoClaveDTO);
        Task<IActionResult> UpdateGrupoClave(string id , GrupoClaveDTO grupoClaveDTO);
        Task<IActionResult> DeleteGrupoClave(string id);
        
    }
}
