using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;


namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoria()
        {
            return await _categoriaService.GetCategorias();
          
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoria(string id)
        {
            return await _categoriaService.GetCategoriaById(id);
          
        }

        // PUT: api/Categoria/5
        // To protect from overposting attacks, see c
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(string id, CategoriaDTO categoriaDTO)
        {
            return await _categoriaService.UpdateCategoria(id,categoriaDTO);
        }

        // POST: api/Categoria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> PostCategoria(CategoriaDTO categoriaDTO)
        {
            return await _categoriaService.CreateCategoria(categoriaDTO);          
        }

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(string id)
        {
            return await _categoriaService.DeleteCategoria(id);
        }
    }

}
