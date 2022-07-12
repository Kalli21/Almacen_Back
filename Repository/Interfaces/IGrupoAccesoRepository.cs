using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IGrupoAccesoRepository
    {
        Task<ICollection<GrupoAccesoDTO>> GetGrupoAccesos();
        Task<GrupoAccesoDTO> GetGrupoAccesoById(string id);
        Task<GrupoAccesoDTO> CreateGrupoAcceso(GrupoAccesoDTO grupoAccesoDTO);
        Task<GrupoAccesoDTO> UpdateGrupoAcceso(GrupoAccesoDTO grupoAccesoDTO);
        Task<bool> DeleteGrupoAcceso(string id);
        
    }
}
