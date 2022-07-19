using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresoController : ControllerBase
    {
        private readonly IIngresoService _ingresoService;

        public IngresoController(IIngresoService ingresoService)
        {
            _ingresoService = ingresoService;
        }

        // GET: api/Ingreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngresoDTO>>> GetIngreso()
        {
            return await _ingresoService.GetIngresos();
        }

        // GET: api/Ingreso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngresoDTO>> GetIngreso(long id)
        {
            return await _ingresoService.GetIngresoById(id);
        }

        // PUT: api/Ingreso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngreso(long id, IngresoDTO ingresoDTO)
        {
            return await _ingresoService.UpdateIngreso(id,ingresoDTO);
        }

        // POST: api/Ingreso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngresoDTO>> PostIngreso(IngresoDTO ingresoDTO)
        {
            return await _ingresoService.CreateIngreso(ingresoDTO);
        }

        // DELETE: api/Ingreso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngreso(long id)
        {
            return await _ingresoService.DeleteIngreso(id);
        }

       
    }
}
