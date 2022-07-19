using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<string> Register(UserDTO userDTO);
        Task<string> Login(UserDTO userDTO);
        Task<bool> UserExiste(string username);
    }
}
