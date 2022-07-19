using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> Register(UserDTO user);
        Task<IActionResult> Login(UserDTO user);
        
    }
}
