using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _articuloRepository;
        protected ResponseDTO _response;

        public ArticuloService(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<ArticuloDTO>> CreateArticulo(ArticuloDTO articuloDTO)
        {
            try
            {
                ArticuloDTO model = await _articuloRepository.CreateArticulo(articuloDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetArticulo", "Articulo", new { id = model.cod_articulo }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el articulo";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteArticulo(long id)
        {
            try
            {
                bool eliminado = await _articuloRepository.DeleteArticulo(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Articulo eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar articulo";
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

        public async Task<ActionResult<ArticuloDTO>> GetArticuloById(long id)
        {
            var articulo = await _articuloRepository.GetArticuloById(id);
            if (articulo == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Articulo no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = articulo;
                _response.DisplayMessage = "Información del articulo";
                return new OkObjectResult(_response);
            }
        }

        public async  Task<ActionResult<IEnumerable<ArticuloDTO>>> GetArticulos()
        {
            try
            {
                var lista = await _articuloRepository.GetArticulos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Articulos";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateArticulo(long id, ArticuloDTO articuloDTO)
        {
            try
            {
                if (id != articuloDTO.cod_articulo)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                ArticuloDTO model = await _articuloRepository.UpdateArticulo(articuloDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el articulo";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}