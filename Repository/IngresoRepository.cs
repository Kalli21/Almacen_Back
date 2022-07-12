using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class IngresoRepository : IIngresoRepository
    {

        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public IngresoRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IngresoDTO> CreateIngreso(IngresoDTO ingresoDTO)
        {
            Ingreso ingreso = _mapper.Map<IngresoDTO, Ingreso>(ingresoDTO);  
            await _db.Ingreso.AddAsync(ingreso);            
            await _db.SaveChangesAsync();
            return _mapper.Map<Ingreso, IngresoDTO>(ingreso);
        
        }

        public async Task<bool> DeleteIngreso(string id)
        {
            try
            {
                Ingreso ingreso = await _db.Ingreso.FindAsync(id);
                if (ingreso == null)
                    return false;
                _db.Ingreso.Remove(ingreso);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IngresoDTO> GetIngresoById(string id)
        {
            Ingreso ingreso = await _db.Ingreso.FindAsync(id);
            return _mapper.Map<IngresoDTO>(ingreso);
        }

        public async Task<ICollection<IngresoDTO>> GetIngresos()
        {
            ICollection<Ingreso> ingresos = await _db.Ingreso.ToListAsync();
            return _mapper.Map<ICollection<IngresoDTO>>(ingresos);
        
        }

        public async Task<IngresoDTO> UpdateIngreso(IngresoDTO ingresoDTO)
        {
            Ingreso ingreso = _mapper.Map<IngresoDTO, Ingreso>(ingresoDTO);        
            _db.Ingreso.Update(ingreso);
            await _db.SaveChangesAsync();
            return _mapper.Map<Ingreso, IngresoDTO >(ingreso);
        
        }
    }
}