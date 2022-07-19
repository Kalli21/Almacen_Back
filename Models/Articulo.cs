using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_ARTICULO")]
public class Articulo
{

    public Articulo()
    {
        this.ControlStock = new HashSet<ControlStock>();
        this.DetIngreso = new HashSet<DetIngreso>();
        this.DetIngresoSalida = new HashSet<DetIngresoSalida>();
        this.DetPedido = new HashSet<DetPedido>();
        this.DetSalida = new HashSet<DetSalida>();

        this.des_articulo = "";
        this.ubicacion = "";
        this.Obs = "";
    }

    [Key]
    public long cod_articulo { get; set; }
    [ForeignKey("cod_und_medida")]
    public string cod_und_medida { get; set; }

    [ForeignKey("Cod_categoria")]
    public string Cod_categoria { get; set; }
    [Required]
    public string nom_articulo { get; set; }
    public string des_articulo { get; set; }
    [Required]
    public bool perecible { get; set; }
    public string ubicacion { get; set; }
    [Required]
    public bool estado { get; set; }
    public byte[]? Imagen { get; set; }
    public Nullable<double> precio_promedio_ref { get; set; }
    public Nullable<double> precio_ultimo_ref { get; set; }
    public string? Obs { get; set; }
    public Nullable<bool> visible { get; set; }

    public virtual Categoria Categoria { get; set; }
    public virtual UnidadMedida UnidadMedida { get; set ;}
    
    [JsonIgnore]
    public virtual ICollection<ControlStock> ControlStock { get; }
    [JsonIgnore]
    public virtual ICollection<DetIngreso> DetIngreso { get; }
    [JsonIgnore]
    public virtual ICollection<DetIngresoSalida> DetIngresoSalida { get; }
    [JsonIgnore]
    public virtual ICollection<DetPedido> DetPedido { get; }
    [JsonIgnore]
    public virtual ICollection<DetSalida> DetSalida { get; }
}