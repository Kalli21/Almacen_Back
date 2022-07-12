using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class AlmacenService : IAlmacenService
    {

        private readonly IAlmacenRepository _almacenRepository;
        protected ResponseDTO _response;

        public AlmacenService(IAlmacenRepository almacenRepository)
        {
            _almacenRepository = almacenRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<AlmacenDTO>> CreateAlmacen(AlmacenDTO almacenDTO)
        {
            try
            {
                AlmacenDTO model = await _almacenRepository.CreateAlmacen(almacenDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetAlmacen", "Almacen", new { id = model.cod_almacen }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el almacen";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteAlmacen(string id)
        {
            try
            {
                bool eliminado = await _almacenRepository.DeleteAlmacen(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Almacen eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar almacen";
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

        public async Task<ActionResult<AlmacenDTO>> GetAlmacenById(string id)
        {
            var alamcen = await _almacenRepository.GetAlmacenById(id);
            if (alamcen == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Almacen no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = alamcen;
                _response.DisplayMessage = "Información del almacen";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<AlmacenDTO>>> GetAlmacenes()
        {
            try
            {
                var lista = await _almacenRepository.GetAlmacenes();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Almacenes";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateAlmacen(string id, AlmacenDTO almacenDTO)
        {
            try
            {
                AlmacenDTO model = await _almacenRepository.UpdateAlmacen(almacenDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el almacen";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}
