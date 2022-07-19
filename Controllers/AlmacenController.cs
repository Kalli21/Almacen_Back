using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlmacenController : ControllerBase
    {
        private readonly IAlmacenService _almacenService;

        public AlmacenController(IAlmacenService almacenService)
        {
            _almacenService = almacenService;
        }

        // GET: api/Almacen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlmacenDTO>>> GetAlmacen()
        {
            return await _almacenService.GetAlmacenes();
            
        }

        // GET: api/Almacen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlmacenDTO>> GetAlmacen(string id)
        {
            return await _almacenService.GetAlmacenById(id);
          
        }

        // PUT: api/Almacen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlmacen(string id, AlmacenDTO almacenDTO)
        {
            return await _almacenService.UpdateAlmacen(id, almacenDTO);
            
        }

        // POST: api/Almacen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlmacenDTO>> PostAlmacen(AlmacenDTO almacenDTO)
        {
            return await _almacenService.CreateAlmacen(almacenDTO);
                        
        }

        // DELETE: api/Almacen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlmacen(string id)
        {
        return await _almacenService.DeleteAlmacen(id);
            
        }

    }
}
