using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class IngresoSalidaRepository : IIngresoSalidaRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public IngresoSalidaRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IngresoSalidaDTO> CreateIngresoSalida(IngresoSalidaDTO ingresoSalidaDTO)
        {
            IngresoSalida ingresoSalida = _mapper.Map<IngresoSalidaDTO, IngresoSalida>(ingresoSalidaDTO);  
            await _db.IngresoSalida.AddAsync(ingresoSalida);            
            await _db.SaveChangesAsync();
            return _mapper.Map<IngresoSalida, IngresoSalidaDTO>(ingresoSalida);
        
        }

        public async  Task<bool> DeleteIngresoSalida(string id)
        {
            try
            {
                IngresoSalida ingresoSalida = await _db.IngresoSalida.FindAsync(id);
                if (ingresoSalida == null)
                    return false;
                _db.IngresoSalida.Remove(ingresoSalida);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IngresoSalidaDTO> GetIngresoSalidaById(string id)
        {
            IngresoSalida ingresoSalida = await _db.IngresoSalida.FindAsync(id);
            return _mapper.Map<IngresoSalidaDTO>(ingresoSalida);
        }

        public async Task<ICollection<IngresoSalidaDTO>> GetIngresoSalidas()
        {
            ICollection<IngresoSalida> ingresoSalidas = await _db.IngresoSalida.ToListAsync();
            return _mapper.Map<ICollection<IngresoSalidaDTO>>(ingresoSalidas);
        
        }

        public async Task<IngresoSalidaDTO> UpdateIngresoSalida(IngresoSalidaDTO ingresoSalidaDTO)
        {
            IngresoSalida ingresoSalida = _mapper.Map<IngresoSalidaDTO, IngresoSalida>(ingresoSalidaDTO);        
            _db.IngresoSalida.Update(ingresoSalida);
            await _db.SaveChangesAsync();
            return _mapper.Map<IngresoSalida, IngresoSalidaDTO >(ingresoSalida);
        
        }
    }
}