using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class DetIngresoService : IDetIngresoService
    {
        private readonly IDetIngresoRepository _detIngresoRepository;
        protected ResponseDTO _response;

        public DetIngresoService(IDetIngresoRepository detIngresoRepository)
        {
            _detIngresoRepository = detIngresoRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<DetIngresoDTO>> CreateDetIngreso(DetIngresoDTO detIngresoDTO)
        {
            try
            {
                DetIngresoDTO model = await _detIngresoRepository.CreateDetIngreso(detIngresoDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetDetIngreso", "DetIngreso", new { id = model.Id }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el detIngreso";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteDetIngreso(long id)
        {
            try
            {
                bool eliminado = await _detIngresoRepository.DeleteDetIngreso(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "DetIngreso eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar detIngreso";
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

        public async Task<ActionResult<DetIngresoDTO>> GetDetIngresoById(long id)
        {
            var detIngreso = await _detIngresoRepository.GetDetIngresoById(id);
            if (detIngreso == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "DetIngreso no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = detIngreso;
                _response.DisplayMessage = "Información del detIngreso";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<DetIngresoDTO>>> GetDetIngresos()
        {
            try
            {
                var lista = await _detIngresoRepository.GetDetIngresos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de DetIngresos";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateDetIngreso(long id, DetIngresoDTO detIngresoDTO)
        {
            try
            {
                if (id != detIngresoDTO.Id)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                DetIngresoDTO model = await _detIngresoRepository.UpdateDetIngreso(detIngresoDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el detIngreso";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}