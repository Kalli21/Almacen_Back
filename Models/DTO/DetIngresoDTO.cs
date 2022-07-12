using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models.DTO;

public class DetIngresoDTO
{
    
    public int Id { get; set; }
    
    public long cod_articulo { get; set; }
    
    public long id_ingreso { get; set; }
    public Nullable<double> cant_art_ingreso { get; set; }
    public Nullable<double> prec_unit_ingreso { get; set; }
    public string? Obs { get; set; }

    public virtual Articulo Articulo { get; set; }
    public virtual Ingreso Ingreso { get; set; }
}