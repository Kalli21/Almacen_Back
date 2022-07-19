using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        // GET: api/Proveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorDTO>>> GetProveedor()
        {
            return await _proveedorService.GetProveedores();
        }

        // GET: api/Proveedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorDTO>> GetProveedor(string id)
        {
            return await _proveedorService.GetProveedorById(id);
        }

        // PUT: api/Proveedor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(string id, ProveedorDTO proveedorDTO)
        {
            return await _proveedorService.UpdateProveedor(id,proveedorDTO);
        }

        // POST: api/Proveedor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProveedorDTO>> PostProveedor(ProveedorDTO proveedorDTO)
        {
            return await _proveedorService.CreateProveedor(proveedorDTO);
        }

        // DELETE: api/Proveedor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(string id)
        {
            return await _proveedorService.DeleteProveedor(id);
        }

       
    }
}
