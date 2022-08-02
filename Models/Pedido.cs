using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_PEDIDO")]
public class Pedido
{

    public Pedido()
    {
        this.DetPedido = new HashSet<DetPedido>();
        this.Salida = new HashSet<Salida>();
    }

    [Key]
    public long id_pedido { get; set; }
    
    public long cod_clave { get; set; }
    
    public string? cod_almacen { get; set; }
    [Required]
    public System.DateTime fecha_pedido { get; set; }
    public Nullable<System.DateTime> fecha_entrega { get; set; }
    public Nullable<System.DateTime> fecha_despacho { get; set; }
    public string? piso_destino { get; set; }
    [Required]
    public string? proc_destino { get; set; }
    [Required]
    public string? prog_destino { get; set; }
    public string? proy_destino { get; set; }
    public string? motivo_solicitud { get; set; }
    [Required]
    public bool autorizado { get; set; }
    [Required]
    public bool urgente { get; set; }
    [Required]
    public bool recepcionado { get; set; }
    [Required]
    public bool enviado { get; set; }
    public string? Obs { get; set; }
    [Required]
    public bool atendido { get; set; }
    public string? pedido_por { get; set; }

    [ForeignKey("cod_almacen")]
    public virtual Almacen? Almacen { get; set; }
    [JsonIgnore]
    public virtual ICollection<DetPedido> DetPedido { get; set; }

    [ForeignKey("cod_clave")]
    public virtual GrupoClave? GrupoClave { get; set; }
    [JsonIgnore]
    public virtual ICollection<Salida> Salida { get; set; }
}