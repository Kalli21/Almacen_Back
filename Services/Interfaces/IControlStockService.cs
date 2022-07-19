using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IControlStockService
    {
        Task<ActionResult<IEnumerable<ControlStockDTO>>> GetControlStocks();
        Task<ActionResult<ControlStockDTO>> GetControlStockById(long id);
        Task<ActionResult<ControlStockDTO>> CreateControlStock(ControlStockDTO controlStockDTO);
        Task<IActionResult> UpdateControlStock(long id , ControlStockDTO controlStockDTO);
        Task<IActionResult> DeleteControlStock(long id);
        
    }
}
