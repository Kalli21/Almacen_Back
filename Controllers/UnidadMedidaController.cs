using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadMedidaController : ControllerBase
    {
        private readonly IUnidadMedidaService _unidadMedidaService;

        public UnidadMedidaController(IUnidadMedidaService unidadMedidaService)
        {
            _unidadMedidaService = unidadMedidaService;
        }

        // GET: api/UnidadMedida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadMedidaDTO>>> GetUnidadMedida()
        {
            return await _unidadMedidaService.GetUnidadMedidas();
        }

        // GET: api/UnidadMedida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadMedidaDTO>> GetUnidadMedida(string id)
        {
            return await _unidadMedidaService.GetUnidadMedidaById(id);
        }

        // PUT: api/UnidadMedida/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadMedida(string id, UnidadMedidaDTO unidadMedidaDTO)
        {
            return await _unidadMedidaService.UpdateUnidadMedida(id,unidadMedidaDTO);
        }

        // POST: api/UnidadMedida
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnidadMedidaDTO>> PostUnidadMedida(UnidadMedidaDTO unidadMedidaDTO)
        {
            return await _unidadMedidaService.CreateUnidadMedida(unidadMedidaDTO);
        }

        // DELETE: api/UnidadMedida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadMedida(string id)
        {
            return await _unidadMedidaService.DeleteUnidadMedida(id);
        }

    }
}
