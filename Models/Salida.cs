using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_SALIDA")]
public class Salida
{

    public Salida()
    {
        this.DetSalida = new HashSet<DetSalida>();
        this.Pedido = new HashSet<Pedido>();
    }
    [Key]
    public long id_salida { get; set; }
    
    public long cod_clave { get; set; }
    
    public string? cod_almacen { get; set; }
    public string? num_guia_salida { get; set; }
    [Required]
    public bool despacho_pedido { get; set; }
    [Required]
    public bool donacion { get; set; }
    [Required]
    public bool venta { get; set; }
    [Required]
    public System.DateTime Fecha_salida { get; set; }
    public string? Obs { get; set; }

    [ForeignKey("cod_almacen")]
    public virtual Almacen? Almacen { get; set; }
    [JsonIgnore]
    public virtual ICollection<DetSalida> DetSalida { get; }

    [ForeignKey("cod_clave")]
    public virtual GrupoClave? GrupoClave { get; set; }
    [JsonIgnore]
    public virtual ICollection<Pedido> Pedido { get; }
}