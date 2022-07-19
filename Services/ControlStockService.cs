using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services

{
    public class ControlStockService : IControlStockService
    {
        private readonly IControlStockRepository _controlStockRepository;
        protected ResponseDTO _response;

        public ControlStockService(IControlStockRepository controlStockRepository)
        {
            _controlStockRepository = controlStockRepository;
            _response = new ResponseDTO();
        } 
        public async Task<ActionResult<ControlStockDTO>> CreateControlStock(ControlStockDTO controlStockDTO)
        {
            try
            {
                ControlStockDTO model = await _controlStockRepository.CreateControlStock(controlStockDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetControlStock", "ControlStock", new { id = model.Id }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el controlStock";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteControlStock(long id)
        {
            try
            {
                bool eliminado = await _controlStockRepository.DeleteControlStock(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "ControlStock eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar ControlStock";
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

        public async Task<ActionResult<ControlStockDTO>> GetControlStockById(long id)
        {
            var controlStock = await _controlStockRepository.GetControlStockById(id);
            if (controlStock == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "ControlStock no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = controlStock;
                _response.DisplayMessage = "Información del ControlStock";
                return new OkObjectResult(_response);
            }throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<ControlStockDTO>>> GetControlStocks()
        {
            try
            {
                var lista = await _controlStockRepository.GetControlStocks();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de ControlStocks";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateControlStock(long id, ControlStockDTO controlStockDTO)
        {
            try
            {
                if (id != controlStockDTO.Id)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                ControlStockDTO model = await _controlStockRepository.UpdateControlStock(controlStockDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el controlStock";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}