using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlStockController : ControllerBase
    {
        private readonly IControlStockService _controlStockService;    

        public ControlStockController(IControlStockService controlStockService)
        {
            _controlStockService = controlStockService;
        }

        // GET: api/ControlStock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ControlStockDTO>>> GetControlStock()
        {
            return await _controlStockService.GetControlStocks();
        }

        // GET: api/ControlStock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ControlStockDTO>> GetControlStock(int id)
        {
            return await _controlStockService.GetControlStockById(id);
        }

        // PUT: api/ControlStock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControlStock(int id, ControlStockDTO controlStockDTO)
        {
            return await _controlStockService.UpdateControlStock(id,controlStockDTO);
        }

        // POST: api/ControlStock
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ControlStockDTO>> PostControlStock(ControlStockDTO controlStockDTO)
        {
            return await _controlStockService.CreateControlStock(controlStockDTO);
        }

        // DELETE: api/ControlStock/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControlStock(int id)
        {
            return await _controlStockService.DeleteControlStock(id);
        }

    }
}
