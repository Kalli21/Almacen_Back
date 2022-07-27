using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoTransaccionController : ControllerBase
    {
        private readonly ITipoTransaccionService _tipoTransaccionService;

        public TipoTransaccionController(ITipoTransaccionService tipoTransaccionService)
        {
            _tipoTransaccionService = tipoTransaccionService;
        }

        // GET: api/TipoTransaccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTransaccionDTO>>> GetTipoTransaccion()
        {
            return await _tipoTransaccionService.GetTipoTransaccions();
        }

        // GET: api/TipoTransaccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTransaccionDTO>> GetTipoTransaccion(string id)
        {
            return await _tipoTransaccionService.GetTipoTransaccionById(id);
        }

        // PUT: api/TipoTransaccion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTransaccion(string id, TipoTransaccionDTO tipoTransaccionDTO)
        {
            return await _tipoTransaccionService.UpdateTipoTransaccion(id,tipoTransaccionDTO);
        }

        // POST: api/TipoTransaccion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoTransaccionDTO>> PostTipoTransaccion(TipoTransaccionDTO tipoTransaccionDTO)
        {
            return await _tipoTransaccionService.CreateTipoTransaccion(tipoTransaccionDTO);
        }

        // DELETE: api/TipoTransaccion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTransaccion(string id)
        {
            return await _tipoTransaccionService.DeleteTipoTransaccion(id);
        }

    }
}
