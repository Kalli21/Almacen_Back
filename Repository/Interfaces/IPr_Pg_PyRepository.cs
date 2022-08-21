using Almacen_Back.Models.DTO;
using Almacen_Back.Models.Request;

namespace Almacen_Back.Repository.Interfaces

{
    public interface IPr_Pg_PyRepository
    {
        Task<ICollection<Pr_Pg_PyDTO>> GetPr_Pg_Pyes();
        Task<Pr_Pg_PyDTO> GetPr_Pg_PyById(int id);
        Task<Pr_Pg_PyDTO> CreatePr_Pg_Py(Pr_Pg_PyDTO Pr_Pg_PyDTO);
        Task<Pr_Pg_PyDTO> UpdatePr_Pg_Py(Pr_Pg_PyDTO Pr_Pg_PyDTO);
        Task<bool> DeletePr_Pg_Py(int id);
        
    }
}
