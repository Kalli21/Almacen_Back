using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services{
    
    public class UnidadMedidaService : IUnidadMedidaService
    {
        private readonly IUnidadMedidaRepository _unidadMedidaRepository;
        protected ResponseDTO _response;

        public UnidadMedidaService(IUnidadMedidaRepository unidadMedidaRepository)
        {
            _unidadMedidaRepository = unidadMedidaRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<UnidadMedidaDTO>> CreateUnidadMedida(UnidadMedidaDTO unidadMedidaDTO)
        {
            try
            {
                UnidadMedidaDTO model = await _unidadMedidaRepository.CreateUnidadMedida(unidadMedidaDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetUnidadMedida", "UnidadMedida", new { id = model.cod_und_medida }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el unidadMedida";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteUnidadMedida(string id)
        {
            try
            {
                bool eliminado = await _unidadMedidaRepository.DeleteUnidadMedida(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "UnidadMedida eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar unidadMedida";
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

        public async Task<ActionResult<UnidadMedidaDTO>> GetUnidadMedidaById(string id)
        {
            var unidadMedida = await _unidadMedidaRepository.GetUnidadMedidaById(id);
            if (unidadMedida == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "UnidadMedida no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = unidadMedida;
                _response.DisplayMessage = "Información del unidadMedida";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<UnidadMedidaDTO>>> GetUnidadMedidas()
        {
            try
            {
                var lista = await _unidadMedidaRepository.GetUnidadMedidas();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de UnidadMedidas";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateUnidadMedida(string id, UnidadMedidaDTO unidadMedidaDTO)
        {
            try
            {
                if (id != unidadMedidaDTO.cod_und_medida)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                UnidadMedidaDTO model = await _unidadMedidaRepository.UpdateUnidadMedida(unidadMedidaDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el unidadMedida";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}