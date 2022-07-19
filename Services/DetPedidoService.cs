using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class DetPedidoService : IDetPedidoService
    {
        private readonly IDetPedidoRepository _detPedidoRepository;
        protected ResponseDTO _response;

        public DetPedidoService(IDetPedidoRepository detPedidoRepository)
        {
            _detPedidoRepository = detPedidoRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<DetPedidoDTO>> CreateDetPedido(DetPedidoDTO detPedidoDTO)
        {
            try
            {
                DetPedidoDTO model = await _detPedidoRepository.CreateDetPedido(detPedidoDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetDetPedido", "DetPedido", new { id = model.Id }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el detPedido";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteDetPedido(long id)
        {
            try
            {
                bool eliminado = await _detPedidoRepository.DeleteDetPedido(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "DetPedido eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar detPedido";
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

        public async Task<ActionResult<DetPedidoDTO>> GetDetPedidoById(long id)
        {
            var detPedido = await _detPedidoRepository.GetDetPedidoById(id);
            if (detPedido == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "DetPedido no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = detPedido;
                _response.DisplayMessage = "Información del detPedido";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<DetPedidoDTO>>> GetDetPedidos()
        {
            try
            {
                var lista = await _detPedidoRepository.GetDetPedidos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de DetPedidos";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateDetPedido(long id, DetPedidoDTO detPedidoDTO)
        {
            try
            {
                if (id != detPedidoDTO.Id)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                DetPedidoDTO model = await _detPedidoRepository.UpdateDetPedido(detPedidoDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el detPedido";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}