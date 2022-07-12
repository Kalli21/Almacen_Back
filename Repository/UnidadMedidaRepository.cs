using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public UnidadMedidaRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UnidadMedidaDTO> CreateUnidadMedida(UnidadMedidaDTO unidadMedidaDTO)
        {
            UnidadMedida unidadMedida = _mapper.Map<UnidadMedidaDTO, UnidadMedida>(unidadMedidaDTO);  
            await _db.UnidadMedida.AddAsync(unidadMedida);            
            await _db.SaveChangesAsync();
            return _mapper.Map<UnidadMedida, UnidadMedidaDTO>(unidadMedida);
        
        }

        public async Task<bool> DeleteUnidadMedida(string id)
        {
            try
            {
                UnidadMedida unidadMedida = await _db.UnidadMedida.FindAsync(id);
                if (unidadMedida == null)
                    return false;
                _db.UnidadMedida.Remove(unidadMedida);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UnidadMedidaDTO> GetUnidadMedidaById(string id)
        {
            UnidadMedida unidadMedida = await _db.UnidadMedida.FindAsync(id);
            return _mapper.Map<UnidadMedidaDTO>(unidadMedida);
        }

        public async Task<ICollection<UnidadMedidaDTO>> GetUnidadMedidas()
        {
            ICollection<UnidadMedida> unidadMedidas = await _db.UnidadMedida.ToListAsync();
            return _mapper.Map<ICollection<UnidadMedidaDTO>>(unidadMedidas);
        
        }

        public async Task<UnidadMedidaDTO> UpdateUnidadMedida(UnidadMedidaDTO unidadMedidaDTO)
        {
            UnidadMedida unidadMedida = _mapper.Map<UnidadMedidaDTO, UnidadMedida>(unidadMedidaDTO);        
            _db.UnidadMedida.Update(unidadMedida);
            await _db.SaveChangesAsync();
            return _mapper.Map<UnidadMedida, UnidadMedidaDTO >(unidadMedida);
        
        }
    }
}