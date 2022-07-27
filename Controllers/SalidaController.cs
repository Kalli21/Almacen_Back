using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalidaController : ControllerBase
    {
        private readonly ISalidaService _salidaService;

        public SalidaController(ISalidaService salidaService)
        {
            _salidaService = salidaService;
        }

        // GET: api/Salidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalidaDTO>>> GetSalida()
        {
            return await _salidaService.GetSalidas();
        }

        // GET: api/Salidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalidaDTO>> GetSalida(long id)
        {
            return await _salidaService.GetSalidaById(id);
        }

        // PUT: api/Salidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalida(long id, SalidaDTO salidaDTO)
        {
            return await _salidaService.UpdateSalida(id,salidaDTO);
        }

        // POST: api/Salidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalidaDTO>> PostSalida(SalidaDTO salidaDTO)
        {
          return await _salidaService.CreateSalida(salidaDTO);
        }

        // DELETE: api/Salidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalida(long id)
        {
            return await _salidaService.DeleteSalida(id);
        }

        
    }
}
