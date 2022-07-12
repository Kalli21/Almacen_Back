using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class AlmacenRepository : IAlmacenRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public AlmacenRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<AlmacenDTO> CreateAlmacen(AlmacenDTO almacenDTO)
        {
            Almacen almacen = _mapper.Map<AlmacenDTO, Almacen>(almacenDTO);  
            await _db.Almacen.AddAsync(almacen);            
            await _db.SaveChangesAsync();
            return _mapper.Map<Almacen, AlmacenDTO>(almacen);
        }
        public async Task<AlmacenDTO> UpdateAlmacen(AlmacenDTO almacenDTO)
        {
            Almacen almacen = _mapper.Map<AlmacenDTO, Almacen>(almacenDTO);        
            _db.Almacen.Update(almacen);
            await _db.SaveChangesAsync();
            return _mapper.Map<Almacen, AlmacenDTO>(almacen);
        }

        public async Task<bool> DeleteAlmacen(string id)
        {
            try
            {
                Almacen almacen = await _db.Almacen.FindAsync(id);
                if (almacen == null)
                    return false;
                _db.Almacen.Remove(almacen);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<AlmacenDTO> GetAlmacenById(string id)
        {
            Almacen almacen = await _db.Almacen.FindAsync(id);
            return _mapper.Map<AlmacenDTO>(almacen);
        }

        public async Task<ICollection<AlmacenDTO>> GetAlmacenes()
        {
            ICollection<Almacen> almacenes = await _db.Almacen.ToListAsync();
            return _mapper.Map<ICollection<AlmacenDTO>>(almacenes);
        }

        
    }
}
