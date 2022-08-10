using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        protected ResponseDTO _response;
        private readonly int records = 100;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _response = new ResponseDTO();
        }
        
        public async Task<ActionResult<PedidoDTO>> CreatePedido(PedidoDTO pedidoDTO)
        {
            try
            {
                PedidoDTO model = await _pedidoRepository.CreatePedido(pedidoDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetPedido", "Pedido", new { id = model.id_pedido }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el pedido";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeletePedido(long id)
        {
            try
            {
                bool eliminado = await _pedidoRepository.DeletePedido(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Pedido eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar pedido";
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

        public async Task<ActionResult<PedidoDTO>> GetPedidoById(long id)
        {
            var pedido = await _pedidoRepository.GetPedidoById(id);
            if (pedido == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Pedido no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = pedido;
                _response.DisplayMessage = "Información del pedido";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<PedidoDTO>>> GetPedidos(int ? page)
        {            
            try
            {
                int _page = page ?? 1;

                var (totlaPages,lista) = await _pedidoRepository.GetPedidos(_page);
                _response.Result = new {
                    pages = totlaPages,
                    actualPage = _page,
                    result = lista                    
                    };
                _response.DisplayMessage = "Lista de Pedidos";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdatePedido(long id, PedidoDTO pedidoDTO)
        {
            try
            {
                if (id != pedidoDTO.id_pedido)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                PedidoDTO model = await _pedidoRepository.UpdatePedido(pedidoDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el pedido";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}