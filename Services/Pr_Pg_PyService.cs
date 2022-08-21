using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using Almacen_Back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services
{
    public class Pr_Pg_PyService : IPr_Pg_PyService
    {
        private readonly IPr_Pg_PyRepository _Pr_Pg_PyRepository;
        protected ResponseDTO _response;

        public Pr_Pg_PyService(IPr_Pg_PyRepository Pr_Pg_PyRepository)
        {
            _Pr_Pg_PyRepository = Pr_Pg_PyRepository;
            _response = new ResponseDTO();
        }

        public async Task<ActionResult<Pr_Pg_PyDTO>> CreatePr_Pg_Py(Pr_Pg_PyDTO Pr_Pg_PyDTO)
        {
            try
            {
                Pr_Pg_PyDTO model = await _Pr_Pg_PyRepository.CreatePr_Pg_Py(Pr_Pg_PyDTO);
                _response.Result = model;
                return new CreatedAtActionResult("GetPr_Pg_Py", "Pr_Pg_Py", new { id = model.id_ppp }, model);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al registrar el Pr_Pg_Py";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }

        public async Task<IActionResult> DeletePr_Pg_Py(int id)
        {
            try
            {
                bool eliminado = await _Pr_Pg_PyRepository.DeletePr_Pg_Py(id);
                if (eliminado)
                {
                    _response.Result = eliminado;
                    _response.DisplayMessage = "Pr_Pg_Py eliminado con exito";
                    return new OkObjectResult(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar Pr_Pg_Py";
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

        public async Task<ActionResult<Pr_Pg_PyDTO>> GetPr_Pg_PyById(int id)
        {
            var Pr_Pg_Py = await _Pr_Pg_PyRepository.GetPr_Pg_PyById(id);
            if (Pr_Pg_Py == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Pr_Pg_Py no Existe";
                return new NotFoundObjectResult(_response);

            }
            else
            {
                _response.Result = Pr_Pg_Py;
                _response.DisplayMessage = "Información del Pr_Pg_Py";
                return new OkObjectResult(_response);
            }
        }

        public async  Task<ActionResult<IEnumerable<Pr_Pg_PyDTO>>> GetPr_Pg_Pys()
        {
            try
            {
                var lista = await _Pr_Pg_PyRepository.GetPr_Pg_Pyes();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Pr_Pg_Pys";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return new OkObjectResult(_response);
        }

        public async Task<IActionResult> UpdatePr_Pg_Py(int id, Pr_Pg_PyDTO Pr_Pg_PyDTO)
        {
            try
            {
                if (id != Pr_Pg_PyDTO.id_ppp)
                {
                    _response.DisplayMessage = "El id no coincide";
                    return new BadRequestObjectResult(_response);
                }
                Pr_Pg_PyDTO model = await _Pr_Pg_PyRepository.UpdatePr_Pg_Py(Pr_Pg_PyDTO);
                _response.Result = model;
                return new OkObjectResult(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el Pr_Pg_Py";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return new BadRequestObjectResult(_response);
            }
        }
    }
}