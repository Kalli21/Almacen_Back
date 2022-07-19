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
            var respuesta = await _userRepository.Register(user);

            if (respuesta == "existe")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario ya Existe";
                return new BadRequestObjectResult(_response);
            }

            if (respuesta == "error") { 
                _response.IsSuccess = false ;
                _response.DisplayMessage = "Error al Crear el Usuario";
                return new BadRequestObjectResult(_response);
            }

            _response.DisplayMessage = "Usuario creado con Exito";
            //_response.Result = respuesta;
            
            user.Token = respuesta;
            user.Password = "";
            _response.Result = user;
            return new OkObjectResult(_response);
        }
    }
}