using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_DET_PEDIDO")]
public class DetPedido
{
    [Key]
    public long Id { get; set; }
    [ForeignKey("id_pedido")]
    public long id_pedido { get; set; }
    [ForeignKey("cod_articulo")]
    public long cod_articulo { get; set; }
    public Nullable<double> cant_pedida { get; set; }
    public Nullable<double> cant_aceptada { get; set; }
    public Nullable<double> cant_entregada { get; set; }
    public Nullable<double> cant_por_entregar { get; set; }
    public Nullable<double> costo_cant_entrega { get; set; }
    [Required]
    public bool pedido_para_compra { get; set; }
    [Required]
    public bool autoriza_compra { get; set; }
    public string Obs { get; set; }
    
    public virtual Articulo? Articulo { get; set; }
    
    public virtual Pedido? Pedido { get; set; }
}