﻿using Almacen_Back.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Almacen_Back.Services.Interfaces
{
    public interface IIngresoService
    {
        Task<ActionResult<IEnumerable<IngresoDTO>>> GetIngresos();
        Task<ActionResult<IngresoDTO>> GetIngresoById(long id);
        Task<ActionResult<IngresoDTO>> CreateIngreso(IngresoDTO ingresoDTO);
        Task<IActionResult> UpdateIngreso(long id , IngresoDTO ingresoDTO);
        Task<IActionResult> DeleteIngreso(long id);
        
    }
}
