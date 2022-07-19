using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models.DTO;

public class IngresoSalidaDTO
{

    public IngresoSalidaDTO()
    {
        this.DetIngresoSalida = new HashSet<DetIngresoSalida>();
    }

    
    public long id_transaccion { get; set; }
    
    public long cod_clave { get; set; }
    
    public bool ingreso { get; set; }
    
    public string cod_tipo_transaccion { get; set; }
    public string num_guia { get; set; }
    public Nullable<System.DateTime> fecha_transaccion { get; set; }
    public string cod_proveedor { get; set; }
    
    public string cod_almacen { get; set; }
    public string Obs { get; set; }
    
    public bool procesado { get; set; }
    
    public bool pendiente { get; set; }
    public Nullable<System.DateTime> fecha_proceso { get; set; }

    [ForeignKey("cod_almacen")]
    public virtual Almacen? Almacen { get; set; }
    
    public virtual ICollection<DetIngresoSalida> DetIngresoSalida { get; }

    [ForeignKey("cod_proveedor")]
    public virtual Proveedor Proveedor { get; set; }

    [ForeignKey("cod_tipo_transaccion")]
    public virtual TipoTransaccion TipoTransaccion { get; set; }
}