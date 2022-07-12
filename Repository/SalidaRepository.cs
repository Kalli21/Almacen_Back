using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class SalidaRepository : ISalidaRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public SalidaRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        
        public async  Task<SalidaDTO> CreateSalida(SalidaDTO salidaDTO)
        {
            Salida salida = _mapper.Map<SalidaDTO, Salida>(salidaDTO);  
            await _db.Salida.AddAsync(salida);            
            await _db.SaveChangesAsync();
            return _mapper.Map<Salida, SalidaDTO>(salida);
        
        }

        public async Task<bool> DeleteSalida(string id)
        {
            try
            {
                Salida salida = await _db.Salida.FindAsync(id);
                if (salida == null)
                    return false;
                _db.Salida.Remove(salida);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<SalidaDTO> GetSalidaById(string id)
        {
            Salida salida = await _db.Salida.FindAsync(id);
            return _mapper.Map<SalidaDTO>(salida);
        }

        public async Task<ICollection<SalidaDTO>> GetSalidas()
        {
            ICollection<Salida> salidas = await _db.Salida.ToListAsync();
            return _mapper.Map<ICollection<SalidaDTO>>(salidas);
        
        }

        public async Task<SalidaDTO> UpdateSalida(SalidaDTO salidaDTO)
        {
            Salida salida = _mapper.Map<SalidaDTO, Salida>(salidaDTO);        
            _db.Salida.Update(salida);
            await _db.SaveChangesAsync();
            return _mapper.Map<Salida, SalidaDTO >(salida);
        
        }
    }
}