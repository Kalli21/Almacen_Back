using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IGrupoAccesoService
    {
        Task<ActionResult<IEnumerable<GrupoAccesoDTO>>> GetGrupoAccesos();
        Task<ActionResult<GrupoAccesoDTO> >GetGrupoAccesoById(string id);
        Task<ActionResult<GrupoAccesoDTO> >CreateGrupoAcceso(GrupoAccesoDTO grupoAccesoDTO);
        Task<IActionResult >UpdateGrupoAcceso(string id , GrupoAccesoDTO grupoAccesoDTO);
        Task<IActionResult >DeleteGrupoAcceso(string id);
        
    }
}
