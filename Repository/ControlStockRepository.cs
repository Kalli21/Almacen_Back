using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class ControlStockRepository : IControlStockRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public ControlStockRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ControlStockDTO> CreateControlStock(ControlStockDTO controlStockDTO)
        {
            ControlStock controlStock = _mapper.Map<ControlStockDTO, ControlStock>(controlStockDTO);  
            await _db.ControlStock.AddAsync(controlStock);            
            await _db.SaveChangesAsync();
            return _mapper.Map<ControlStock, ControlStockDTO>(controlStock);
        
        }

        public async Task<bool> DeleteControlStock(string id)
        {
            try
            {
                ControlStock controlStock = await _db.ControlStock.FindAsync(id);
                if (controlStock == null)
                    return false;
                _db.ControlStock.Remove(controlStock);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ControlStockDTO> GetControlStockById(string id)
        {
            ControlStock controlStock = await _db.ControlStock.FindAsync(id);
            return _mapper.Map<ControlStockDTO>(controlStock);
        }

        public async Task<ICollection<ControlStockDTO>> GetControlStocks()
        {
            ICollection<ControlStock> controlStocks = await _db.ControlStock.ToListAsync();
            return _mapper.Map<ICollection<ControlStockDTO>>(controlStocks);
        
        }

        public async Task<ControlStockDTO> UpdateControlStock(ControlStockDTO controlStockDTO)
        {
            ControlStock controlStock = _mapper.Map<ControlStockDTO, ControlStock>(controlStockDTO);        
            _db.ControlStock.Update(controlStock);
            await _db.SaveChangesAsync();
            return _mapper.Map<ControlStock, ControlStockDTO >(controlStock);
        
        }
    }
}