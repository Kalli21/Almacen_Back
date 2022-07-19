using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Almacen_Back.Services
{
    public class DetSalidaService : IDetSalidaService
    {
        private readonly IDetSalidaRepository _detSalidaRepository;
        protected ResponseDTO _response;

        public DetSalidaService(IDetSalidaRepository detSalidaRepository)
        {
            _detSalidaRepository = detSalidaRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<DetSalidaDTO>> CreateDetSalida(DetSalidaDTO detSalidaDTO)
        {
            try
            {
                DetSalidaDTO model = await _detSalidaRepository.CreateDetSalida(detSalidaDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetDetSalida", "DetSalida", new { id = model.Id }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el detSalida";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteDetSalida(long id)
        {
            try
            {
                bool eliminado = await _detSalidaRepository.DeleteDetSalida(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "DetSalida eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar detSalida";
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

        public async Task<ActionResult<DetSalidaDTO>> GetDetSalidaById(long id)
        {
             var detSalida = await _detSalidaRepository.GetDetSalidaById(id);
            if (detSalida == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "DetSalida no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = detSalida;
                _response.DisplayMessage = "Información del detSalida";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<DetSalidaDTO>>> GetDetSalidas()
        {
            try
            {
                var lista = await _detSalidaRepository.GetDetSalidas();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de DetSalidas";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateDetSalida(long id, DetSalidaDTO detSalidaDTO)
        {
            try
            {
                if (id != detSalidaDTO.Id)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                DetSalidaDTO model = await _detSalidaRepository.UpdateDetSalida(detSalidaDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el detSalida";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}