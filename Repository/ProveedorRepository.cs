using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public ProveedorRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProveedorDTO> CreateProveedor(ProveedorDTO proveedorDTO)
        {
            Proveedor proveedor = _mapper.Map<ProveedorDTO, Proveedor>(proveedorDTO);  
            await _db.Proveedor.AddAsync(proveedor);            
            await _db.SaveChangesAsync();
            return _mapper.Map<Proveedor, ProveedorDTO>(proveedor);
        
        }

        public async Task<bool> DeleteProveedor(string id)
        {
            try
            {
                Proveedor proveedor = await _db.Proveedor.FindAsync(id);
                if (proveedor == null)
                    return false;
                _db.Proveedor.Remove(proveedor);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProveedorDTO> GetProveedorById(string id)
        {
            Proveedor proveedor = await _db.Proveedor.FindAsync(id);
            return _mapper.Map<ProveedorDTO>(proveedor);
        }

        public async Task<ICollection<ProveedorDTO>> GetProveedores()
        {
            ICollection<Proveedor> proveedores = await _db.Proveedor.ToListAsync();
            return _mapper.Map<ICollection<ProveedorDTO>>(proveedores);
        
        }

        public async Task<ProveedorDTO> UpdateProveedor(ProveedorDTO proveedorDTO)
        {
            Proveedor proveedor = _mapper.Map<ProveedorDTO, Proveedor>(proveedorDTO);        
            _db.Proveedor.Update(proveedor);
            await _db.SaveChangesAsync();
            return _mapper.Map<Proveedor, ProveedorDTO >(proveedor);
        
        }
    }
}