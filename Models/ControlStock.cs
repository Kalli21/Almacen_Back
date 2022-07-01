using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_CONTROL_STOCK")]
public class ControlStock
{
    public string cod_almacen { get; set; }
    public long cod_articulo { get; set; }
    public Nullable<decimal> cant_fisica { get; set; }
    public Nullable<decimal> cant_real { get; set; }
    public Nullable<decimal> cant_minima_reposicion { get; set; }
    public string Obs { get; set; }

    [ForeignKey("cod_almacen")]
    public virtual Almacen Almacen { get; set; }
    [ForeignKey("cod_articulo")]
    public virtual Articulo Articulo { get; set; }
}