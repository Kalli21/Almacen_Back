using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class SalidaService : ISalidaService
    {
        private readonly ISalidaRepository _salidaRepository;
        protected ResponseDTO _response;

        public SalidaService(ISalidaRepository salidaRepository)
        {
            _salidaRepository = salidaRepository;
            _response = new ResponseDTO();
        }


        public async Task<ActionResult<SalidaDTO>> CreateSalida(SalidaDTO salidaDTO)
        {
            try
            {
                SalidaDTO model = await _salidaRepository.CreateSalida(salidaDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetSalida", "Salida", new { id = model.id_salida }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el salida";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteSalida(long id)
        {
            try
            {
                bool eliminado = await _salidaRepository.DeleteSalida(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Salida eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar salida";
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

        public async Task<ActionResult<SalidaDTO>> GetSalidaById(long id)
        {
            var salida = await _salidaRepository.GetSalidaById(id);
            if (salida == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Salida no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = salida;
                _response.DisplayMessage = "Información del salida";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<SalidaDTO>>> GetSalidas()
        {
            try
            {
                var lista = await _salidaRepository.GetSalidas();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Salidas";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateSalida(long id, SalidaDTO salidaDTO)
        {
            try
            {
                if (id != salidaDTO.id_salida)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                SalidaDTO model = await _salidaRepository.UpdateSalida(salidaDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el salida";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}