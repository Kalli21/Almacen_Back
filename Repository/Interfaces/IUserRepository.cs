using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDTO> Register(UserDTO userDTO);
        Task<string> Login(UserDTO userDTO);
        Task<bool> UserExiste(string username);

        Task<ICollection<UserDTO>> GetUsers();
        Task<UserDTO> GetUserById(string username);
        Task<UserDTO> UpdateUser(UserDTO UserDTO);
        Task<bool> DeleteUser(string username);
    }
}
