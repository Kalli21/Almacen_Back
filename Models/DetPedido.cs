using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_DET_PEDIDO")]
public class DetPedido
{

    public long id_pedido { get; set; }
    public long cod_articulo { get; set; }
    public Nullable<decimal> cant_pedida { get; set; }
    public Nullable<decimal> cant_aceptada { get; set; }
    public Nullable<decimal> cant_entregada { get; set; }
    public Nullable<decimal> cant_por_entregar { get; set; }
    public Nullable<decimal> costo_cant_entrega { get; set; }
    public bool pedido_para_compra { get; set; }
    public bool autoriza_compra { get; set; }
    public string Obs { get; set; }

    [ForeignKey("cod_articulo")]
    public virtual Articulo Articulo { get; set; }
    [ForeignKey("id_pedido")]
    public virtual Pedido Pedido { get; set; }
}