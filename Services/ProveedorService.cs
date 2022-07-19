using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;
        protected ResponseDTO _response;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
            _response = new ResponseDTO();
        }
        
        public async Task<ActionResult<ProveedorDTO>> CreateProveedor(ProveedorDTO proveedorDTO)
        {
            try
            {
                ProveedorDTO model = await _proveedorRepository.CreateProveedor(proveedorDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetProveedor", "Proveedor", new { id = model.cod_proveedor }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el proveedor";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteProveedor(string id)
        {
            try
            {
                bool eliminado = await _proveedorRepository.DeleteProveedor(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Proveedor eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar proveedor";
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

        public async Task<ActionResult<ProveedorDTO>> GetProveedorById(string id)
        {
            var proveedor = await _proveedorRepository.GetProveedorById(id);
            if (proveedor == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Proveedor no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = proveedor;
                _response.DisplayMessage = "Información del proveedor";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<ProveedorDTO>>> GetProveedores()
        {
            try
            {
                var lista = await _proveedorRepository.GetProveedores();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Proveedors";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateProveedor(string id, ProveedorDTO proveedorDTO)
        {
            try
            {
                if (id != proveedorDTO.cod_proveedor)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                ProveedorDTO model = await _proveedorRepository.UpdateProveedor(proveedorDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el proveedor";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}