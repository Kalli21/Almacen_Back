using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IPr_Pg_PyService
    {
        Task<ActionResult<IEnumerable<Pr_Pg_PyDTO>>> GetPr_Pg_Pys();
        Task<ActionResult<Pr_Pg_PyDTO>> GetPr_Pg_PyById(int id);
        Task<ActionResult<Pr_Pg_PyDTO>> CreatePr_Pg_Py(Pr_Pg_PyDTO Pr_Pg_PyDTO);
        Task<IActionResult> UpdatePr_Pg_Py(int id , Pr_Pg_PyDTO Pr_Pg_PyDTO);
        Task<IActionResult> DeletePr_Pg_Py(int id);
        
    }
}
