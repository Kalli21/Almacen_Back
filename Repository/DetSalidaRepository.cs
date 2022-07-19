using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class DetSalidaRepository : IDetSalidaRepository
    {

        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public DetSalidaRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DetSalidaDTO> CreateDetSalida(DetSalidaDTO detSalidaDTO)
        {
            DetSalida detSalida = _mapper.Map<DetSalidaDTO, DetSalida>(detSalidaDTO);  
            await _db.DetSalida.AddAsync(detSalida);            
            await _db.SaveChangesAsync();
            return _mapper.Map<DetSalida, DetSalidaDTO>(detSalida);
        
        }

        public async  Task<bool> DeleteDetSalida(long id)
        {
            try
            {
                DetSalida detSalida = await _db.DetSalida.FindAsync(id);
                if (detSalida == null)
                    return false;
                _db.DetSalida.Remove(detSalida);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<DetSalidaDTO> GetDetSalidaById(long id)
        {
            DetSalida detSalida = await _db.DetSalida.FindAsync(id);
            return _mapper.Map<DetSalidaDTO>(detSalida);
        }

        public async  Task<ICollection<DetSalidaDTO>> GetDetSalidas()
        {
            ICollection<DetSalida> detSalidas = await _db.DetSalida.ToListAsync();
            return _mapper.Map<ICollection<DetSalidaDTO>>(detSalidas);
        
        }

        public async Task<DetSalidaDTO> UpdateDetSalida(DetSalidaDTO detSalidaDTO)
        {
            DetSalida detSalida = _mapper.Map<DetSalidaDTO, DetSalida>(detSalidaDTO);        
            _db.DetSalida.Update(detSalida);
            await _db.SaveChangesAsync();
            return _mapper.Map<DetSalida, DetSalidaDTO >(detSalida);
        
        }
    }
}