using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetIngresoController : ControllerBase
    {
        private readonly IDetIngresoService _detIngresoService;

        public DetIngresoController(IDetIngresoService detIngresoService)
        {
            _detIngresoService = detIngresoService;
        }

        // GET: api/DetIngreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetIngresoDTO>>> GetDetIngreso()
        {
            return await _detIngresoService.GetDetIngresos();
        }

        // GET: api/DetIngreso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetIngresoDTO>> GetDetIngreso(int id)
        {
            return await _detIngresoService.GetDetIngresoById(id);
        }

        // PUT: api/DetIngreso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetIngreso(int id, DetIngresoDTO detIngresoDTO)
        {
            return await _detIngresoService.UpdateDetIngreso(id,detIngresoDTO); 
        }

        // POST: api/DetIngreso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetIngresoDTO>> PostDetIngreso(DetIngresoDTO detIngresoDTO)
        {
            return await _detIngresoService.CreateDetIngreso(detIngresoDTO);
        }

        // DELETE: api/DetIngreso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetIngreso(int id)
        {
            return await _detIngresoService.DeleteDetIngreso(id);
        }

    }
}
