using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class GrupoClaveRepository : IGrupoClaveRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public GrupoClaveRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GrupoClaveDTO> CreateGrupoClave(GrupoClaveDTO grupoClaveDTO)
        {
            GrupoClave grupoClave = _mapper.Map<GrupoClaveDTO, GrupoClave>(grupoClaveDTO);  
            await _db.GrupoClave.AddAsync(grupoClave);            
            await _db.SaveChangesAsync();
            return _mapper.Map<GrupoClave, GrupoClaveDTO>(grupoClave);
        
        }

        public async Task<bool> DeleteGrupoClave(string id)
        {
            try
            {
                GrupoClave grupoClave = await _db.GrupoClave.FindAsync(id);
                if (grupoClave == null)
                    return false;
                _db.GrupoClave.Remove(grupoClave);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<GrupoClaveDTO> GetGrupoClaveById(string id)
        {
            GrupoClave grupoClave = await _db.GrupoClave.FindAsync(id);
            return _mapper.Map<GrupoClaveDTO>(grupoClave);
        }

        public async Task<ICollection<GrupoClaveDTO>> GetGrupoClaves()
        {
            ICollection<GrupoClave> grupoClaves = await _db.GrupoClave.ToListAsync();
            return _mapper.Map<ICollection<GrupoClaveDTO>>(grupoClaves);
        
        }

        public async Task<GrupoClaveDTO> UpdateGrupoClave(GrupoClaveDTO grupoClaveDTO)
        {
            GrupoClave grupoClave = _mapper.Map<GrupoClaveDTO, GrupoClave>(grupoClaveDTO);        
            _db.GrupoClave.Update(grupoClave);
            await _db.SaveChangesAsync();
            return _mapper.Map<GrupoClave, GrupoClaveDTO >(grupoClave);
        
        }
    }
}