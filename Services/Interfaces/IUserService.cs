using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> Register(UserDTO user);
        Task<IActionResult> Login(UserDTO user);

        Task<ActionResult<IEnumerable<UserDTO>>> GetUsers();
        Task<ActionResult<UserDTO>> GetUserById(string username);
        Task<IActionResult> UpdateUser(string username , UserDTO UserDTO);
        Task<IActionResult> DeleteUser(string username);
        
    }
}
