using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface ITipoTransaccionRepository
    {
        Task<ICollection<TipoTransaccionDTO>> GetTipoTransaccions();
        Task<TipoTransaccionDTO> GetTipoTransaccionById(string id);
        Task<TipoTransaccionDTO> CreateTipoTransaccion(TipoTransaccionDTO tipoTransaccionDTO);
        Task<TipoTransaccionDTO> UpdateTipoTransaccion(TipoTransaccionDTO tipoTransaccionDTO);
        Task<bool> DeleteTipoTransaccion(string id);
        
    }
}
