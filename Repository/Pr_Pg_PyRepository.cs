using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class Pr_Pg_PyRepository : IPr_Pg_PyRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public Pr_Pg_PyRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Pr_Pg_PyDTO> CreatePr_Pg_Py(Pr_Pg_PyDTO Pr_Pg_PyDTO)
        {
            Pr_Pg_Py Pr_Pg_Py = _mapper.Map<Pr_Pg_PyDTO, Pr_Pg_Py>(Pr_Pg_PyDTO);
            await _db.Pr_Pg_Py.AddAsync(Pr_Pg_Py);
            await _db.SaveChangesAsync();
            return _mapper.Map<Pr_Pg_Py, Pr_Pg_PyDTO>(Pr_Pg_Py);
        }

        public async Task<bool> DeletePr_Pg_Py(int id)
        {
            try
            {
                Pr_Pg_Py Pr_Pg_Py = await _db.Pr_Pg_Py.FindAsync(id);
                if (Pr_Pg_Py == null)
                    return false;
                _db.Pr_Pg_Py.Remove(Pr_Pg_Py);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Pr_Pg_PyDTO> GetPr_Pg_PyById(int id)
        {
            Pr_Pg_Py Pr_Pg_Py = await _db.Pr_Pg_Py.FindAsync(id);
            return _mapper.Map<Pr_Pg_PyDTO>(Pr_Pg_Py);
        }

        public async Task<ICollection<Pr_Pg_PyDTO>> GetPr_Pg_Pyes()
        {
            ICollection<Pr_Pg_Py> Pr_Pg_Pyes = await _db.Pr_Pg_Py.ToListAsync();
            return _mapper.Map<ICollection<Pr_Pg_PyDTO>>(Pr_Pg_Pyes);
        }

        public async Task<Pr_Pg_PyDTO> UpdatePr_Pg_Py(Pr_Pg_PyDTO Pr_Pg_PyDTO)
        {
            Pr_Pg_Py Pr_Pg_Py = _mapper.Map<Pr_Pg_PyDTO, Pr_Pg_Py>(Pr_Pg_PyDTO);
            _db.Pr_Pg_Py.Update(Pr_Pg_Py);
            await _db.SaveChangesAsync();
            return _mapper.Map<Pr_Pg_Py, Pr_Pg_PyDTO>(Pr_Pg_Py);
        }
    }
}