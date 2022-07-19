using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IArticuloService
    {
        Task<ActionResult<IEnumerable<ArticuloDTO>>> GetArticulos();
        Task<ActionResult<ArticuloDTO>> GetArticuloById(long id);
        Task<ActionResult<ArticuloDTO>> CreateArticulo(ArticuloDTO articuloDTO);
        Task<IActionResult> UpdateArticulo(long id , ArticuloDTO articuloDTO);
        Task<IActionResult> DeleteArticulo(long id);
        
    }
}
