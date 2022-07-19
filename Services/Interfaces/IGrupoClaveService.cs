using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IGrupoClaveService
    {
        Task<ActionResult<IEnumerable<GrupoClaveDTO>>> GetGrupoClaves();
        Task<ActionResult<GrupoClaveDTO>> GetGrupoClaveById(long id);
        Task<ActionResult<GrupoClaveDTO>> CreateGrupoClave(GrupoClaveDTO grupoClaveDTO);
        Task<IActionResult> UpdateGrupoClave(long id , GrupoClaveDTO grupoClaveDTO);
        Task<IActionResult> DeleteGrupoClave(long id);
        
    }
}
