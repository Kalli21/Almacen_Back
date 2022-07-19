using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class IngresoSalidaService : IIngresoSalidaService
    {

        private readonly IIngresoSalidaRepository _ingresoSalidaRepository;
        protected ResponseDTO _response;

        public IngresoSalidaService(IIngresoSalidaRepository ingresoSalidaRepository)
        {
            _ingresoSalidaRepository = ingresoSalidaRepository;
            _response = new ResponseDTO();
        }
        
        public async Task<ActionResult<IngresoSalidaDTO>> CreateIngresoSalida(IngresoSalidaDTO ingresoSalidaDTO)
        {
            try
            {
                IngresoSalidaDTO model = await _ingresoSalidaRepository.CreateIngresoSalida(ingresoSalidaDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetIngresoSalida", "IngresoSalida", new { id = model.id_transaccion }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el ingresoSalida";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteIngresoSalida(long id)
        {
            try
            {
                bool eliminado = await _ingresoSalidaRepository.DeleteIngresoSalida(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "IngresoSalida eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar ingresoSalida";
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

        public async Task<ActionResult<IngresoSalidaDTO>> GetIngresoSalidaById(long id)
        {
            var ingresoSalida = await _ingresoSalidaRepository.GetIngresoSalidaById(id);
            if (ingresoSalida == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "IngresoSalida no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = ingresoSalida;
                _response.DisplayMessage = "Información del ingresoSalida";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<IngresoSalidaDTO>>> GetIngresoSalidas()
        {
            try
            {
                var lista = await _ingresoSalidaRepository.GetIngresoSalidas();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de IngresoSalidas";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateIngresoSalida(long id, IngresoSalidaDTO ingresoSalidaDTO)
        {
            try
            {
                if (id != ingresoSalidaDTO.id_transaccion)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                IngresoSalidaDTO model = await _ingresoSalidaRepository.UpdateIngresoSalida(ingresoSalidaDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el ingresoSalida";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}