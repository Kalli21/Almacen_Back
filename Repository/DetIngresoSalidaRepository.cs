using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class DetIngresoSalidaRepository : IDetIngresoSalidaRepository
    {

        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public DetIngresoSalidaRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DetIngresoSalidaDTO> CreateDetIngresoSalida(DetIngresoSalidaDTO detIngresoSalidaDTO)
        {
            DetIngresoSalida detIngresoSalida = _mapper.Map<DetIngresoSalidaDTO, DetIngresoSalida>(detIngresoSalidaDTO);  
            await _db.DetIngresoSalida.AddAsync(detIngresoSalida);            
            await _db.SaveChangesAsync();
            return _mapper.Map<DetIngresoSalida, DetIngresoSalidaDTO>(detIngresoSalida);
        
        }

        public async Task<bool> DeleteDetIngresoSalida(string id)
        {
            try
            {
                DetIngresoSalida detIngresoSalida = await _db.DetIngresoSalida.FindAsync(id);
                if (detIngresoSalida == null)
                    return false;
                _db.DetIngresoSalida.Remove(detIngresoSalida);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<DetIngresoSalidaDTO> GetDetIngresoSalidaById(string id)
        {
            DetIngresoSalida detIngresoSalida = await _db.DetIngresoSalida.FindAsync(id);
            return _mapper.Map<DetIngresoSalidaDTO>(detIngresoSalida);
        }

        public async Task<ICollection<DetIngresoSalidaDTO>> GetDetIngresoSalidas()
        {
            ICollection<DetIngresoSalida> detIngresoSalidas = await _db.DetIngresoSalida.ToListAsync();
            return _mapper.Map<ICollection<DetIngresoSalidaDTO>>(detIngresoSalidas);
        
        }

        public async Task<DetIngresoSalidaDTO> UpdateDetIngresoSalida(DetIngresoSalidaDTO detIngresoSalidaDTO)
        {
            DetIngresoSalida detIngresoSalida = _mapper.Map<DetIngresoSalidaDTO, DetIngresoSalida>(detIngresoSalidaDTO);        
            _db.DetIngresoSalida.Update(detIngresoSalida);
            await _db.SaveChangesAsync();
            return _mapper.Map<DetIngresoSalida, DetIngresoSalidaDTO >(detIngresoSalida);
        
        }
    }
}