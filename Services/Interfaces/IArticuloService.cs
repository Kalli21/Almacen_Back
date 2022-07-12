using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IArticuloService
    {
        Task<ActionResult<IEnumerable<ArticuloDTO>>> GetArticulos();
        Task<ActionResult<ArticuloDTO>> GetArticuloById(string id);
        Task<ActionResult<ArticuloDTO>> CreateArticulo(ArticuloDTO articuloDTO);
        Task<IActionResult> UpdateArticulo(string id , ArticuloDTO articuloDTO);
        Task<IActionResult> DeleteArticulo(string id);
        
    }
}
