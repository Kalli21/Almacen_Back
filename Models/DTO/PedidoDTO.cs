using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models.DTO;

public class PedidoDTO
{

    public PedidoDTO()
    {
        this.DetPedido = new HashSet<DetPedido>();
    }

    
    public long id_pedido { get; set; }
    
    public long cod_clave { get; set; }
    
    public string? cod_almacen { get; set; }
    
    public System.DateTime fecha_pedido { get; set; }
    public Nullable<System.DateTime> fecha_entrega { get; set; }
    public Nullable<System.DateTime> fecha_despacho { get; set; }
    public string? piso_destino { get; set; }
    
    public string? proc_destino { get; set; }
    
    public string? prog_destino { get; set; }
    public string? proy_destino { get; set; }
    public string? motivo_solicitud { get; set; }
    
    public bool autorizado { get; set; }
    
    public bool urgente { get; set; }
    
    public bool recepcionado { get; set; }
    
    public bool enviado { get; set; }
    public string? Obs { get; set; }
    
    public bool atendido { get; set; }
    public string? pedido_por { get; set; }

    public virtual Almacen? Almacen { get; set; }
    
    public virtual ICollection<DetPedido> DetPedido { get; set; }

    public virtual GrupoClave? GrupoClave { get; set; }
    
}