using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Almacen_Back.Models;

[Table("AL_CONTROL_STOCK")]
public class ControlStock
{   
    [Key]
    public long Id { get; set; }
    [ForeignKey("cod_almacen")]
    public string? cod_almacen { get; set; }
    [ForeignKey("cod_articulo")]
    public long cod_articulo { get; set; }
    public Nullable<double> cant_fisica { get; set; }
    public Nullable<double> cant_real { get; set; }
    public Nullable<double> cant_minima_reposicion { get; set; }
    public string Obs { get; set; }
    [JsonIgnore]
    public virtual Almacen Almacen { get; set; }
    [JsonIgnore]    
    public virtual Articulo Articulo { get; set; }
}