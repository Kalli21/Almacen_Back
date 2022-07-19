using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class DetIngresoSalidaService : IDetIngresoSalidaService
    {
        private readonly IDetIngresoSalidaRepository _detIngresoSalidaRepository;
        protected ResponseDTO _response;

        public DetIngresoSalidaService(IDetIngresoSalidaRepository detIngresoSalidaRepository)
        {
            _detIngresoSalidaRepository = detIngresoSalidaRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<DetIngresoSalidaDTO>> CreateDetIngresoSalida(DetIngresoSalidaDTO detIngresoSalidaDTO)
        {
            try
            {
                DetIngresoSalidaDTO model = await _detIngresoSalidaRepository.CreateDetIngresoSalida(detIngresoSalidaDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetDetIngresoSalida", "DetIngresoSalida", new { id = model.Id }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el DetIngresoSalida";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteDetIngresoSalida(long id)
        {
            try
            {
                bool eliminado = await _detIngresoSalidaRepository.DeleteDetIngresoSalida(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "DetIngresoSalida eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar detIngresoSalida";
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

        public async Task<ActionResult<DetIngresoSalidaDTO>> GetDetIngresoSalidaById(long id)
        {
            var detIngresoSalida = await _detIngresoSalidaRepository.GetDetIngresoSalidaById(id);
            if (detIngresoSalida == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "DetIngresoSalida no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = detIngresoSalida;
                _response.DisplayMessage = "Información del DetIngresoSalida";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<DetIngresoSalidaDTO>>> GetDetIngresoSalidas()
        {
            try
            {
                var lista = await _detIngresoSalidaRepository.GetDetIngresoSalidas();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de DetIngresoSalidas";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateDetIngresoSalida(long id, DetIngresoSalidaDTO detIngresoSalidaDTO)
        {
            try
            {
                if (id != detIngresoSalidaDTO.Id)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                DetIngresoSalidaDTO model = await _detIngresoSalidaRepository.UpdateDetIngresoSalida(detIngresoSalidaDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el detIngresoSalida";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}