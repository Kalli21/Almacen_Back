using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class TipoTransaccionService : ITipoTransaccionService
    {
        private readonly ITipoTransaccionRepository _tipoTransaccionRepository;
        protected ResponseDTO _response;

        public TipoTransaccionService(ITipoTransaccionRepository tipoTransaccionRepository)
        {
            _tipoTransaccionRepository = tipoTransaccionRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<TipoTransaccionDTO>> CreateTipoTransaccion(TipoTransaccionDTO tipoTransaccionDTO)
        {
            try
            {
                TipoTransaccionDTO model = await _tipoTransaccionRepository.CreateTipoTransaccion(tipoTransaccionDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetTipoTransaccion", "TipoTransaccion", new { id = model.cod_tipo_transaccion }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el tipoTransaccion";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteTipoTransaccion(string id)
        {
            try
            {
                bool eliminado = await _tipoTransaccionRepository.DeleteTipoTransaccion(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "TipoTransaccion eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar tipoTransaccion";
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

        public async Task<ActionResult<TipoTransaccionDTO>> GetTipoTransaccionById(string id)
        {
            var tipoTransaccion = await _tipoTransaccionRepository.GetTipoTransaccionById(id);
            if (tipoTransaccion == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "TipoTransaccion no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = tipoTransaccion;
                _response.DisplayMessage = "Información del tipoTransaccion";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<TipoTransaccionDTO>>> GetTipoTransaccions()
        {
            try
            {
                var lista = await _tipoTransaccionRepository.GetTipoTransaccions();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de TipoTransaccions";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateTipoTransaccion(string id, TipoTransaccionDTO tipoTransaccionDTO)
        {
            try
            {
                if (id != tipoTransaccionDTO.cod_tipo_transaccion)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                TipoTransaccionDTO model = await _tipoTransaccionRepository.UpdateTipoTransaccion(tipoTransaccionDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el tipoTransaccion";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}