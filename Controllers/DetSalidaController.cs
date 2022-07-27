using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetSalidaController : ControllerBase
    {
        private readonly IDetSalidaService _detSalidaService;

        public DetSalidaController(IDetSalidaService detSalidaService)
        {
            _detSalidaService = detSalidaService;
        }

        // GET: api/DetSalida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetSalidaDTO>>> GetDetSalida()
        {
            return await _detSalidaService.GetDetSalidas();
        }

        // GET: api/DetSalida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetSalidaDTO>> GetDetSalida(int id)
        {
            return await _detSalidaService.GetDetSalidaById(id);
        }

        // PUT: api/DetSalida/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetSalida(int id, DetSalidaDTO detSalidaDTO)
        {
            return await _detSalidaService.UpdateDetSalida(id,detSalidaDTO);
        }

        // POST: api/DetSalida
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetSalidaDTO>> PostDetSalida(DetSalidaDTO detSalidaDTO)
        {
            return await _detSalidaService.CreateDetSalida(detSalidaDTO);
        }

        // DELETE: api/DetSalida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetSalida(int id)
        {
            return await _detSalidaService.DeleteDetSalida(id);
        }

    }
}
