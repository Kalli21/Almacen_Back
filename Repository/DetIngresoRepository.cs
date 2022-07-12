using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class DetIngresoRepository : IDetIngresoRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public DetIngresoRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DetIngresoDTO> CreateDetIngreso(DetIngresoDTO detIngresoDTO)
        {
            DetIngreso detIngreso = _mapper.Map<DetIngresoDTO, DetIngreso>(detIngresoDTO);  
            await _db.DetIngreso.AddAsync(detIngreso);            
            await _db.SaveChangesAsync();
            return _mapper.Map<DetIngreso, DetIngresoDTO>(detIngreso);
        
        }

        public async Task<bool> DeleteDetIngreso(string id)
        {
            try
            {
                DetIngreso detIngreso = await _db.DetIngreso.FindAsync(id);
                if (detIngreso == null)
                    return false;
                _db.DetIngreso.Remove(detIngreso);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<DetIngresoDTO> GetDetIngresoById(string id)
        {
            DetIngreso detIngreso = await _db.DetIngreso.FindAsync(id);
            return _mapper.Map<DetIngresoDTO>(detIngreso);
        }

        public async Task<ICollection<DetIngresoDTO>> GetDetIngresos()
        {
            ICollection<DetIngreso> detIngresos = await _db.DetIngreso.ToListAsync();
            return _mapper.Map<ICollection<DetIngresoDTO>>(detIngresos);
        
        }

        public async Task<DetIngresoDTO> UpdateDetIngreso(DetIngresoDTO detIngresoDTO)
        {
            DetIngreso detIngreso = _mapper.Map<DetIngresoDTO, DetIngreso>(detIngresoDTO);        
            _db.DetIngreso.Update(detIngreso);
            await _db.SaveChangesAsync();
            return _mapper.Map<DetIngreso, DetIngresoDTO >(detIngreso);
        
        }
    }
}