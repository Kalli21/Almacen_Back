using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class DetPedidoRepository : IDetPedidoRepository
    {
        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public DetPedidoRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DetPedidoDTO> CreateDetPedido(DetPedidoDTO detPedidoDTO)
        {
            DetPedido detPedido = _mapper.Map<DetPedidoDTO, DetPedido>(detPedidoDTO);  
            await _db.DetPedido.AddAsync(detPedido);            
            await _db.SaveChangesAsync();
            return _mapper.Map<DetPedido, DetPedidoDTO>(detPedido);
        
        }

        public async Task<bool> DeleteDetPedido(long id)
        {
            try
            {
                DetPedido detPedido = await _db.DetPedido.FindAsync(id);
                if (detPedido == null)
                    return false;
                _db.DetPedido.Remove(detPedido);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<DetPedidoDTO> GetDetPedidoById(long id)
        {
            DetPedido detPedido = await _db.DetPedido.FindAsync(id);
            return _mapper.Map<DetPedidoDTO>(detPedido);
        }

        public async Task<ICollection<DetPedidoDTO>> GetDetPedidos()
        {
            ICollection<DetPedido> detPedidos = await _db.DetPedido.ToListAsync();
            return _mapper.Map<ICollection<DetPedidoDTO>>(detPedidos);
        
        }

        public async Task<DetPedidoDTO> UpdateDetPedido(DetPedidoDTO detPedidoDTO)
        {
            DetPedido detPedido = _mapper.Map<DetPedidoDTO, DetPedido>(detPedidoDTO);        
            _db.DetPedido.Update(detPedido);
            await _db.SaveChangesAsync();
            return _mapper.Map<DetPedido, DetPedidoDTO >(detPedido);
        
        }
    }
}