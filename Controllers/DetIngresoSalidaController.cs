using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetIngresoSalidaController : ControllerBase
    {
        private readonly IDetIngresoSalidaService _detIngresoSalidaService;

        public DetIngresoSalidaController(IDetIngresoSalidaService detIngresoSalidaService)
        {
            _detIngresoSalidaService = detIngresoSalidaService;
        }

        // GET: api/DetIngresoSalida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetIngresoSalidaDTO>>> GetDetIngresoSalida()
        {
            return await _detIngresoSalidaService.GetDetIngresoSalidas();
        }

        // GET: api/DetIngresoSalida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetIngresoSalidaDTO>> GetDetIngresoSalida(int id)
        {
            return await _detIngresoSalidaService.GetDetIngresoSalidaById(id);
        }

        // PUT: api/DetIngresoSalida/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetIngresoSalida(int id, DetIngresoSalidaDTO detIngresoSalidaDTO)
        {
            return await _detIngresoSalidaService.UpdateDetIngresoSalida(id,detIngresoSalidaDTO);
        }

        // POST: api/DetIngresoSalida
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetIngresoSalidaDTO>> PostDetIngresoSalida(DetIngresoSalidaDTO detIngresoSalidaDTO)
        {
            return await _detIngresoSalidaService.CreateDetIngresoSalida(detIngresoSalidaDTO);
        }

        // DELETE: api/DetIngresoSalida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetIngresoSalida(int id)
        {
            return await _detIngresoSalidaService.DeleteDetIngresoSalida(id);
        }

    }
}
