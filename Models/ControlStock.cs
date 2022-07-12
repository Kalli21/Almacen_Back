using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_CONTROL_STOCK")]
public class ControlStock
{   
    [Key]
    public int Id { get; set; }
    [Required]
    public string? cod_almacen { get; set; }
    [Required]
    public long cod_articulo { get; set; }
    public Nullable<double> cant_fisica { get; set; }
    public Nullable<double> cant_real { get; set; }
    public Nullable<double> cant_minima_reposicion { get; set; }
    public string Obs { get; set; }

    [ForeignKey("cod_almacen")]
    public virtual Almacen Almacen { get; set; }
    [ForeignKey("cod_articulo")]
    public virtual Articulo Articulo { get; set; }
}