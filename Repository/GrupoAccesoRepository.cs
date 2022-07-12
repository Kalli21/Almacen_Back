using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class GrupoAccesoRepository : IGrupoAccesoRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public GrupoAccesoRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GrupoAccesoDTO> CreateGrupoAcceso(GrupoAccesoDTO grupoAccesoDTO)
        {
            GrupoAcceso grupoAcceso = _mapper.Map<GrupoAccesoDTO, GrupoAcceso>(grupoAccesoDTO);  
            await _db.GrupoAcceso.AddAsync(grupoAcceso);            
            await _db.SaveChangesAsync();
            return _mapper.Map<GrupoAcceso, GrupoAccesoDTO>(grupoAcceso);
        
        }

        public async Task<bool> DeleteGrupoAcceso(string id)
        {
            try
            {
                GrupoAcceso grupoAcceso = await _db.GrupoAcceso.FindAsync(id);
                if (grupoAcceso == null)
                    return false;
                _db.GrupoAcceso.Remove(grupoAcceso);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<GrupoAccesoDTO> GetGrupoAccesoById(string id)
        {
            GrupoAcceso grupoAcceso = await _db.GrupoAcceso.FindAsync(id);
            return _mapper.Map<GrupoAccesoDTO>(grupoAcceso);
        }

        public async Task<ICollection<GrupoAccesoDTO>> GetGrupoAccesos()
        {
            ICollection<GrupoAcceso> grupoAccesos = await _db.GrupoAcceso.ToListAsync();
            return _mapper.Map<ICollection<GrupoAccesoDTO>>(grupoAccesos);
        
        }

        public async Task<GrupoAccesoDTO> UpdateGrupoAcceso(GrupoAccesoDTO grupoAccesoDTO)
        {
            GrupoAcceso grupoAcceso = _mapper.Map<GrupoAccesoDTO, GrupoAcceso>(grupoAccesoDTO);        
            _db.GrupoAcceso.Update(grupoAcceso);
            await _db.SaveChangesAsync();
            return _mapper.Map<GrupoAcceso, GrupoAccesoDTO >(grupoAcceso);
        
        }
    }
}