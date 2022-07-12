using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<ICollection<CategoriaDTO>> GetCategorias();
        Task<CategoriaDTO> GetCategoriaById(string id);
        Task<CategoriaDTO> CreateCategoria(CategoriaDTO categoriaDTO);
        Task<CategoriaDTO> UpdateCategoria(CategoriaDTO categoriaDTO);
        Task<bool> DeleteCategoria(string id);
        
    }
}
