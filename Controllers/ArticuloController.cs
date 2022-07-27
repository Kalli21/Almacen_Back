
using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        // GET: api/Articulo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloDTO>>> GetArticulo()
        {
            return await _articuloService.GetArticulos();          
        }

        // GET: api/Articulo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloDTO>> GetArticulo(long id)
        {
            return await _articuloService.GetArticuloById(id);          
        }

        // PUT: api/Articulo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(long id, ArticuloDTO articuloDTO)
        {
            return await _articuloService.UpdateArticulo(id,articuloDTO);
        }

        // POST: api/Articulo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArticuloDTO>> PostArticulo(ArticuloDTO articuloDTO)
        {
            return await _articuloService.CreateArticulo(articuloDTO);        
        }

        // DELETE: api/Articulo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(long id)
        {
            return await _articuloService.DeleteArticulo(id);
        }

    }
}
