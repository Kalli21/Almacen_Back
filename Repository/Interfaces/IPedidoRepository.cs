﻿using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IPedidoRepository
    {
        Task<(decimal ,ICollection<PedidoDTO>)> GetPedidos(int page);
        Task<PedidoDTO> GetPedidoById(long id);
        Task<PedidoDTO> CreatePedido(PedidoDTO pedidoDTO);
        Task<PedidoDTO> UpdatePedido(PedidoDTO pedidoDTO);
        Task<bool> DeletePedido(long id);
        
    }
}
