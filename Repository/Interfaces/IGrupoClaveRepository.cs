using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IGrupoClaveRepository
    {
        Task<ICollection<GrupoClaveDTO>> GetGrupoClaves();
        Task<GrupoClaveDTO> GetGrupoClaveById(string id);
        Task<GrupoClaveDTO> CreateGrupoClave(GrupoClaveDTO grupoClaveDTO);
        Task<GrupoClaveDTO> UpdateGrupoClave(GrupoClaveDTO grupoClaveDTO);
        Task<bool> DeleteGrupoClave(string id);
        
    }
}
