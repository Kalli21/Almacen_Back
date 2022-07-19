using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IControlStockRepository
    {
        Task<ICollection<ControlStockDTO>> GetControlStocks();
        Task<ControlStockDTO> GetControlStockById(long id);
        Task<ControlStockDTO> CreateControlStock(ControlStockDTO controlStockDTO);
        Task<ControlStockDTO> UpdateControlStock(ControlStockDTO controlStockDTO);
        Task<bool> DeleteControlStock(long id);
        
    }
}
