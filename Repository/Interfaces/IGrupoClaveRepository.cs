using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IGrupoClaveRepository
    {
        Task<ICollection<GrupoClaveDTO>> GetGrupoClaves();
        Task<GrupoClaveDTO> GetGrupoClaveById(long id);
        Task<GrupoClaveDTO> CreateGrupoClave(GrupoClaveDTO grupoClaveDTO);
        Task<GrupoClaveDTO> UpdateGrupoClave(GrupoClaveDTO grupoClaveDTO);
        Task<bool> DeleteGrupoClave(long id);
        
    }
}
