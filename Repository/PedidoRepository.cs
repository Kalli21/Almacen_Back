using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Almacen_Back.Repository
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly Almacen_Back_Context _db;
        private IMapper _mapper;

        public PedidoRepository(Almacen_Back_Context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PedidoDTO> CreatePedido(PedidoDTO pedidoDTO)
        {
            Pedido pedido = _mapper.Map<PedidoDTO, Pedido>(pedidoDTO);  
            await _db.Pedido.AddAsync(pedido);            
            await _db.SaveChangesAsync();
            return _mapper.Map<Pedido, PedidoDTO>(pedido);
        
        }

        public async Task<bool> DeletePedido(long id)
        {
            try
            {
                Pedido pedido = await _db.Pedido.FindAsync(id);
                if (pedido == null)
                    return false;
                _db.Pedido.Remove(pedido);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<PedidoDTO> GetPedidoById(long id)
        {
            Pedido pedido = await _db.Pedido.FindAsync(id);
            return _mapper.Map<PedidoDTO>(pedido);
        }

        public async Task<ICollection<PedidoDTO>> GetPedidos()
        {
            ICollection<Pedido> pedidos = await _db.Pedido.ToListAsync();
            return _mapper.Map<ICollection<PedidoDTO>>(pedidos);
        
        }

        public async Task<PedidoDTO> UpdatePedido(PedidoDTO pedidoDTO)
        {
            Pedido pedido = _mapper.Map<PedidoDTO, Pedido>(pedidoDTO);        
            _db.Pedido.Update(pedido);
            await _db.SaveChangesAsync();
            return _mapper.Map<Pedido, PedidoDTO >(pedido);
        
        }
    }
}