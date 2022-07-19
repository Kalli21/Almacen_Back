using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class IngresoService : IIngresoService
    {
        private readonly IIngresoRepository _ingresoRepository;
        protected ResponseDTO _response;

        public IngresoService(IIngresoRepository ingresoRepository)
        {
            _ingresoRepository = ingresoRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<IngresoDTO>> CreateIngreso(IngresoDTO ingresoDTO)
        {
            try
            {
                IngresoDTO model = await _ingresoRepository.CreateIngreso(ingresoDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetIngreso", "Ingreso", new { id = model.id_ingreso }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el ingreso";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async  Task<IActionResult> DeleteIngreso(long id)
        {
            try
            {
                bool eliminado = await _ingresoRepository.DeleteIngreso(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Ingreso eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar ingreso";
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

        public async Task<ActionResult<IngresoDTO>> GetIngresoById(long id)
        {
            var ingreso = await _ingresoRepository.GetIngresoById(id);
            if (ingreso == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Ingreso no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = ingreso;
                _response.DisplayMessage = "Información del ingreso";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<IngresoDTO>>> GetIngresos()
        {
            try
            {
                var lista = await _ingresoRepository.GetIngresos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Ingresos";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateIngreso(long id, IngresoDTO ingresoDTO)
        {
            try
            {
                if (id != ingresoDTO.id_ingreso)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                IngresoDTO model = await _ingresoRepository.UpdateIngreso(ingresoDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el ingreso";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}