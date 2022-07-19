using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public ArticuloRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ArticuloDTO> CreateArticulo(ArticuloDTO articuloDTO)
        {
            Articulo articulo = _mapper.Map<ArticuloDTO, Articulo>(articuloDTO);  
            await _db.Articulo.AddAsync(articulo);            
            await _db.SaveChangesAsync();
            return _mapper.Map<Articulo, ArticuloDTO>(articulo);
        }

        public async Task<bool> DeleteArticulo(long id)
        {
             try
            {
                Articulo articulo = await _db.Articulo.FindAsync(id);
                if (articulo == null)
                    return false;
                _db.Articulo.Remove(articulo);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ArticuloDTO> GetArticuloById(long id)
        {
            Articulo articulo = await _db.Articulo.FindAsync(id);
            return _mapper.Map<ArticuloDTO>(articulo);
        }

        public async Task<ICollection<ArticuloDTO>> GetArticulos()
        {
            ICollection<Articulo> articulos = await _db.Articulo.ToListAsync();
            return _mapper.Map<ICollection<ArticuloDTO>>(articulos);
        }

        public async Task<ArticuloDTO> UpdateArticulo(ArticuloDTO articuloDTO)
        {
            Articulo articulo = _mapper.Map<ArticuloDTO, Articulo>(articuloDTO);        
            _db.Articulo.Update(articulo);
            await _db.SaveChangesAsync();
            return _mapper.Map<Articulo, ArticuloDTO >(articulo);
        }
    }
}