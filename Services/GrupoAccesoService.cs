using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class GrupoAccesoService : IGrupoAccesoService
    {
        private readonly IGrupoAccesoRepository _grupoAccesoRepository;
        protected ResponseDTO _response;

        public GrupoAccesoService(IGrupoAccesoRepository grupoAccesoRepository)
        {
            _grupoAccesoRepository = grupoAccesoRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<GrupoAccesoDTO>> CreateGrupoAcceso(GrupoAccesoDTO grupoAccesoDTO)
        {
            try
            {
                GrupoAccesoDTO model = await _grupoAccesoRepository.CreateGrupoAcceso(grupoAccesoDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetGrupoAcceso", "GrupoAcceso", new { id = model.Cod_grupo }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el grupoAcceso";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteGrupoAcceso(string id)
        {
            try
            {
                bool eliminado = await _grupoAccesoRepository.DeleteGrupoAcceso(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "GrupoAcceso eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar grupoAcceso";
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

        public async Task<ActionResult<GrupoAccesoDTO>> GetGrupoAccesoById(string id)
        {
            var grupoAcceso = await _grupoAccesoRepository.GetGrupoAccesoById(id);
            if (grupoAcceso == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "GrupoAcceso no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = grupoAcceso;
                _response.DisplayMessage = "Información del grupoAcceso";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<GrupoAccesoDTO>>> GetGrupoAccesos()
        {
            try
            {
                var lista = await _grupoAccesoRepository.GetGrupoAccesos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de GrupoAccesos";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateGrupoAcceso(string id, GrupoAccesoDTO grupoAccesoDTO)
        {
            try
            {
                if (id != grupoAccesoDTO.Cod_grupo)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                GrupoAccesoDTO model = await _grupoAccesoRepository.UpdateGrupoAcceso(grupoAccesoDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el grupoAcceso";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}