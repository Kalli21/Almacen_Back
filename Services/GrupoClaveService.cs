using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class GrupoClaveService : IGrupoClaveService
    {
        private readonly IGrupoClaveRepository _grupoClaveRepository;
        protected ResponseDTO _response;

        public GrupoClaveService(IGrupoClaveRepository grupoClaveRepository)
        {
            _grupoClaveRepository = grupoClaveRepository;
            _response = new ResponseDTO();
        }
        public async Task<ActionResult<GrupoClaveDTO>> CreateGrupoClave(GrupoClaveDTO grupoClaveDTO)
        {
            try
            {
                GrupoClaveDTO model = await _grupoClaveRepository.CreateGrupoClave(grupoClaveDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetGrupoClave", "GrupoClave", new { id = model.cod_clave }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el grupoClave";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeleteGrupoClave(long id)
        {
            try
            {
                bool eliminado = await _grupoClaveRepository.DeleteGrupoClave(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "GrupoClave eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar grupoClave";
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

        public async Task<ActionResult<GrupoClaveDTO>> GetGrupoClaveById(long id)
        {
            var grupoClave = await _grupoClaveRepository.GetGrupoClaveById(id);
            if (grupoClave == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "GrupoClave no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = grupoClave;
                _response.DisplayMessage = "Información del grupoClave";
                return new OkObjectResult(_response);
            }
        }

        public async Task<ActionResult<IEnumerable<GrupoClaveDTO>>> GetGrupoClaves()
        {
            try
            {
                var lista = await _grupoClaveRepository.GetGrupoClaves();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de GrupoClaves";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdateGrupoClave(long id, GrupoClaveDTO grupoClaveDTO)
        {
            try
            {
                if (id != grupoClaveDTO.cod_clave)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                GrupoClaveDTO model = await _grupoClaveRepository.UpdateGrupoClave(grupoClaveDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el grupoClave";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}