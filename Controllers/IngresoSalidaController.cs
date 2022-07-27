using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngresoSalidaController : ControllerBase
    {
        private readonly IIngresoSalidaService _ingresoSalidaService;

        public IngresoSalidaController(IIngresoSalidaService ingresoSalidaService)
        {
            _ingresoSalidaService = ingresoSalidaService;
        }

        // GET: api/IngresoSalida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngresoSalidaDTO>>> GetIngresoSalida()
        {
            return await _ingresoSalidaService.GetIngresoSalidas();
        }

        // GET: api/IngresoSalida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngresoSalidaDTO>> GetIngresoSalida(long id)
        {
            return await _ingresoSalidaService.GetIngresoSalidaById(id);
        }

        // PUT: api/IngresoSalida/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngresoSalida(long id, IngresoSalidaDTO ingresoSalidaDTO)
        {
            return await _ingresoSalidaService.UpdateIngresoSalida(id,ingresoSalidaDTO);
        }

        // POST: api/IngresoSalida
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngresoSalidaDTO>> PostIngresoSalida(IngresoSalidaDTO ingresoSalidaDTO)
        {
            return await _ingresoSalidaService.CreateIngresoSalida(ingresoSalidaDTO);
        }

        // DELETE: api/IngresoSalida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngresoSalida(long id)
        {
            return await _ingresoSalidaService.DeleteIngresoSalida(id);
        }

    }
}
