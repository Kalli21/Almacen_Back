using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        protected ResponseDTO _response;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<CategoriaDTO>> CreateCategoria(CategoriaDTO categoriaDTO)
        {
            try
            {
                CategoriaDTO model = await _categoriaRepository.CreateCategoria(categoriaDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetCategoria", "Categoria", new { id = model.Cod_categoria }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el categoria";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteCategoria(string id)
        {
            try
            {
                bool eliminado = await _categoriaRepository.DeleteCategoria(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Categoria eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar categoria";
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

        public async Task<ActionResult<CategoriaDTO>> GetCategoriaById(string id)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(id);
            if (categoria == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Categoria no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = categoria;
                _response.DisplayMessage = "Información del categoria";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias()
        {
            try
            {
                var lista = await _categoriaRepository.GetCategorias();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Categorias";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateCategoria(string id, CategoriaDTO categoriaDTO)
        {
            try
            {
                if (id != categoriaDTO.Cod_categoria)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                CategoriaDTO model = await _categoriaRepository.UpdateCategoria(categoriaDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el categoria";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}