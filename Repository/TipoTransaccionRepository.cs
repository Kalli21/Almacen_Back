using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class TipoTransaccionRepository : ITipoTransaccionRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public TipoTransaccionRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TipoTransaccionDTO> CreateTipoTransaccion(TipoTransaccionDTO tipoTransaccionDTO)
        {
            TipoTransaccion tipoTransaccion = _mapper.Map<TipoTransaccionDTO, TipoTransaccion>(tipoTransaccionDTO);  
            await _db.TipoTransaccion.AddAsync(tipoTransaccion);            
            await _db.SaveChangesAsync();
            return _mapper.Map<TipoTransaccion, TipoTransaccionDTO>(tipoTransaccion);
        
        }

        public async Task<bool> DeleteTipoTransaccion(string id)
        {
            try
            {
                TipoTransaccion tipoTransaccion = await _db.TipoTransaccion.FindAsync(id);
                if (tipoTransaccion == null)
                    return false;
                _db.TipoTransaccion.Remove(tipoTransaccion);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TipoTransaccionDTO> GetTipoTransaccionById(string id)
        {
            TipoTransaccion tipoTransaccion = await _db.TipoTransaccion.FindAsync(id);
            return _mapper.Map<TipoTransaccionDTO>(tipoTransaccion);
        }

        public async Task<ICollection<TipoTransaccionDTO>> GetTipoTransaccions()
        {
            ICollection<TipoTransaccion> tipoTransaccions = await _db.TipoTransaccion.ToListAsync();
            return _mapper.Map<ICollection<TipoTransaccionDTO>>(tipoTransaccions);
        
        }

        public async Task<TipoTransaccionDTO> UpdateTipoTransaccion(TipoTransaccionDTO tipoTransaccionDTO)
        {
            TipoTransaccion tipoTransaccion = _mapper.Map<TipoTransaccionDTO, TipoTransaccion>(tipoTransaccionDTO);        
            _db.TipoTransaccion.Update(tipoTransaccion);
            await _db.SaveChangesAsync();
            return _mapper.Map<TipoTransaccion, TipoTransaccionDTO >(tipoTransaccion);
        
        }
    }
}