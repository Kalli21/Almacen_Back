using Microsoft.AspNetCore.Mvc;
using Almacen_Back.Models.DTO;
using Almacen_Back.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Almacen_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDTO user)
        {
            return await _userService.Register(user);   
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDTO user) 
        {
            return await _userService.Login(user);   
        }

    }

}
