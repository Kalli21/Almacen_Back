using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias();
        Task<ActionResult<CategoriaDTO>> GetCategoriaById(string id);
        Task<ActionResult<CategoriaDTO>> CreateCategoria(CategoriaDTO categoriaDTO);
        Task<IActionResult> UpdateCategoria(string id , CategoriaDTO categoriaDTO);
        Task<IActionResult> DeleteCategoria(string id);
        
    }
}
