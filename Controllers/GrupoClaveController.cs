using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoClaveController : ControllerBase
    {
        private readonly IGrupoClaveService _grupoClaveService;

        public GrupoClaveController(IGrupoClaveService grupoClaveService)
        {
            _grupoClaveService = grupoClaveService;
        }

        // GET: api/GrupoClave
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoClaveDTO>>> GetGrupoClave()
        {
            return await _grupoClaveService.GetGrupoClaves();
        }

        // GET: api/GrupoClave/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoClaveDTO>> GetGrupoClave(long id)
        {
            return await _grupoClaveService.GetGrupoClaveById(id);
        }

        // PUT: api/GrupoClave/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoClave(long id, GrupoClaveDTO grupoClaveDTO)
        {
            return await _grupoClaveService.UpdateGrupoClave(id,grupoClaveDTO);
        }

        // POST: api/GrupoClave
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrupoClaveDTO>> PostGrupoClave(GrupoClaveDTO grupoClaveDTO)
        {
            return await _grupoClaveService.CreateGrupoClave(grupoClaveDTO);
        }

        // DELETE: api/GrupoClave/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoClave(long id)
        {
            return await _grupoClaveService.DeleteGrupoClave(id);
        }

        
    }
}
