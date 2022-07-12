﻿using Almacen_Back.Models.DTO;

namespace Almacen_Back.Repository.Interfaces
{
    public interface IArticuloRepository
    {
        Task<ICollection<ArticuloDTO>> GetArticulos();
        Task<ArticuloDTO> GetArticuloById(string id);
        Task<ArticuloDTO> CreateArticulo(ArticuloDTO articuloDTO);
        Task<ArticuloDTO> UpdateArticulo(ArticuloDTO articuloDTO);
        Task<bool> DeleteArticulo(string id);
        
    }
}
