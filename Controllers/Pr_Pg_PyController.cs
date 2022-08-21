using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Pr_Pg_PyController : ControllerBase
    {
        private readonly IPr_Pg_PyService _Pg_PyService;

        public Pr_Pg_PyController(IPr_Pg_PyService Pg_PyService)
        {
            _Pg_PyService = Pg_PyService;
        }

        // GET: api/Pr_Pg_Py
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pr_Pg_PyDTO>>> GetPr_Pg_Py()
        {
            return await _Pg_PyService.GetPr_Pg_Pys();
            
        }

        // GET: api/Pr_Pg_Py/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pr_Pg_PyDTO>> GetPr_Pg_Py(int id)
        {
            return await _Pg_PyService.GetPr_Pg_PyById(id);
          
        }

        // PUT: api/Pr_Pg_Py/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPr_Pg_Py(int id, Pr_Pg_PyDTO pr_Pg_PyDTO)
        {
            return await _Pg_PyService.UpdatePr_Pg_Py(id, pr_Pg_PyDTO);
            
        }

        // POST: api/Pr_Pg_Py
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pr_Pg_PyDTO>> PostPr_Pg_Py(Pr_Pg_PyDTO pr_Pg_PyDTO)
        {
            return await _Pg_PyService.CreatePr_Pg_Py(pr_Pg_PyDTO);
                        
        }

        // DELETE: api/Pr_Pg_Py/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePr_Pg_Py(int id)
        {
        return await _Pg_PyService.DeletePr_Pg_Py(id);
            
        }

    }
}
