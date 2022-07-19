using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_ALMACEN")]
public class Almacen
{

    public Almacen()
    {
        this.ControlStock = new HashSet<ControlStock>();
        this.Ingreso = new HashSet<Ingreso>();
        this.IngresoSalida = new HashSet<IngresoSalida>();
        this.Pedido = new HashSet<Pedido>();
        this.Salida = new HashSet<Salida>();

        this.dir_almacen = "";
        this.tlf_almacen = "";
        this.Obs = "";

    }
    
    [Key]
    public string cod_almacen { get; set; }

    [Required]
    public string? nom_almacen { get; set; }
    public string dir_almacen { get; set; }
    public string tlf_almacen { get; set; }
    public string? Obs { get; set; }

    [JsonIgnore]
    public virtual ICollection<ControlStock> ControlStock { get; }
    [JsonIgnore]
    public virtual ICollection<Ingreso> Ingreso { get; }
    [JsonIgnore]
    public virtual ICollection<IngresoSalida> IngresoSalida { get; }
    [JsonIgnore]
    public virtual ICollection<Pedido> Pedido { get; }
    [JsonIgnore]
    public virtual ICollection<Salida> Salida { get; }
}