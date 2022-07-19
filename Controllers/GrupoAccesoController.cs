using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoAccesoController : ControllerBase
    {
        private readonly IGrupoAccesoService _grupoAccesoService;

        public GrupoAccesoController(IGrupoAccesoService grupoAccesoService)
        {
            _grupoAccesoService = grupoAccesoService;
        }

        // GET: api/GrupoAcceso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoAccesoDTO>>> GetGrupoAcceso()
        {
            return await _grupoAccesoService.GetGrupoAccesos();
        }

        // GET: api/GrupoAcceso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoAccesoDTO>> GetGrupoAcceso(string id)
        {
            return await _grupoAccesoService.GetGrupoAccesoById(id);
        }

        // PUT: api/GrupoAcceso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoAcceso(string id, GrupoAccesoDTO grupoAccesoDTO)
        {
            return await _grupoAccesoService.UpdateGrupoAcceso(id,grupoAccesoDTO);
        }

        // POST: api/GrupoAcceso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoAccesoDTO>> PostGrupoAcceso(GrupoAccesoDTO grupoAccesoDTO)
        {
            return await _grupoAccesoService.CreateGrupoAcceso(grupoAccesoDTO);
        }

        // DELETE: api/GrupoAcceso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoAcceso(string id)
        {
            return await _grupoAccesoService.DeleteGrupoAcceso(id);
        }

    }
}
