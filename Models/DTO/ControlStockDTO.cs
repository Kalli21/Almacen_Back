
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models.DTO;

public class ControlStockDTO
{   
    
    public int Id { get; set; }
    
    public string? cod_almacen { get; set; }
    
    public long cod_articulo { get; set; }
    public Nullable<double> cant_fisica { get; set; }
    public Nullable<double> cant_real { get; set; }
    public Nullable<double> cant_minima_reposicion { get; set; }
    public string? Obs { get; set; }

    public virtual Almacen? Almacen { get; set; }
    public virtual Articulo? Articulo { get; set; }
}