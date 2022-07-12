using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public CategoriaRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> CreateCategoria(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);  
            await _db.Categoria.AddAsync(categoria);            
            await _db.SaveChangesAsync();
            return _mapper.Map<Categoria, CategoriaDTO>(categoria);
        
        }

        public async Task<bool> DeleteCategoria(string id)
        {
            try
            {
                Categoria categoria = await _db.Categoria.FindAsync(id);
                if (categoria == null)
                    return false;
                _db.Categoria.Remove(categoria);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CategoriaDTO> GetCategoriaById(string id)
        {
            Categoria categoria = await _db.Categoria.FindAsync(id);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<ICollection<CategoriaDTO>> GetCategorias()
        {
            ICollection<Categoria> categorias = await _db.Categoria.ToListAsync();
            return _mapper.Map<ICollection<CategoriaDTO>>(categorias);
        
        }

        public async Task<CategoriaDTO> UpdateCategoria(CategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<CategoriaDTO, Categoria>(categoriaDTO);        
            _db.Categoria.Update(categoria);
            await _db.SaveChangesAsync();
            return _mapper.Map<Categoria, CategoriaDTO >(categoria);
        
        }
    }
}