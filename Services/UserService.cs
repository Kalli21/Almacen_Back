using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        protected ResponseDTO _response;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new ResponseDTO();
        }

        public async Task<IActionResult> Login(UserDTO user)
        {
            var respuesta = await _userRepository.Login(user);

            if (respuesta=="nouser")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario no existe";
                return new BadRequestObjectResult(_response);
            }

            if (respuesta == "wrongpassword")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Password incorrecto";
                return new BadRequestObjectResult(_response);
            }

            //_response.Result = respuesta;
            _response.DisplayMessage = "Usuario conectado";
            
            user.Token = respuesta;
            user.Password = "";
            _response.Result = user;

            return new OkObjectResult(_response);

            
        }

        public async Task<IActionResult> Register(UserDTO user)
        {
            UserDTO model = await _userRepository.Register(user);

            if (model.Token == "existe")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario ya Existe";
                return new BadRequestObjectResult(_response);
            }

            if (model.Token == "error") { 
                _response.IsSuccess = false ;
                _response.DisplayMessage = "Error al Crear el Usuario";
                return new BadRequestObjectResult(_response);
            }

            _response.DisplayMessage = "Usuario creado con Exito";
            //_response.Result = respuesta;
            
            // user.Token = respuesta;
            // user.Password = "";
            _response.Result = model;
            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> DeleteUser(string username)
        {
            try
            {
                bool eliminado = await _userRepository.DeleteUser(username);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "User eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar user";
                    return new BadRequestObjectResult(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);

            }
        }

        public async Task<ActionResult<UserDTO>> GetUserById(string username)
        {
            var user = await _userRepository.GetUserById(username);
            if (user == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "User no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = user;
                _response.DisplayMessage = "Información del user";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            try
            {
                var lista = await _userRepository.GetUsers();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Usuarios";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateUser(string username, UserDTO userDTO)
        {
            try
            {
                if (username != userDTO.UserName)
                {
                    _response.DisplayMessage = "El username no coincide";
                    return new BadRequestObjectResult(_response);
                }
                UserDTO model = await _userRepository.UpdateUser(userDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el usuario";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}