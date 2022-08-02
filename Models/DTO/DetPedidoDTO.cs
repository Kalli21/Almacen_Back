using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models.DTO;

public class DetPedidoDTO
{
    
    public int Id { get; set; }
    
    public long id_pedido { get; set; }
    
    public long cod_articulo { get; set; }
    public Nullable<double> cant_pedida { get; set; }
    public Nullable<double> cant_aceptada { get; set; }
    public Nullable<double> cant_entregada { get; set; }
    public Nullable<double> cant_por_entregar { get; set; }
    public Nullable<double> costo_cant_entrega { get; set; }
    
    public bool pedido_para_compra { get; set; }
    
    public bool autoriza_compra { get; set; }
    public string? Obs { get; set; }

    public virtual Articulo? Articulo { get; set; }
    public virtual Pedido? Pedido { get; set; }
}