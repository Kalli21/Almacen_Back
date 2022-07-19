using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_INGRESO_SALIDA")]
public class IngresoSalida
{

    public IngresoSalida()
    {
        this.DetIngresoSalida = new HashSet<DetIngresoSalida>();
    }

    [Key]
    public long id_transaccion { get; set; }
    [Required]
    public long cod_clave { get; set; }
    [Required]
    public bool ingreso { get; set; }
    [ForeignKey("cod_tipo_transaccion")]
    public string cod_tipo_transaccion { get; set; }
    public string num_guia { get; set; }
    public Nullable<System.DateTime> fecha_transaccion { get; set; }
    [ForeignKey("cod_proveedor")]
    public string cod_proveedor { get; set; }
    [ForeignKey("cod_almacen")]
    public string cod_almacen { get; set; }
    public string Obs { get; set; }
    [Required]
    public bool procesado { get; set; }
    [Required]
    public bool pendiente { get; set; }
    public Nullable<System.DateTime> fecha_proceso { get; set; }

    public virtual Almacen? Almacen { get; set; }
    [JsonIgnore]
    public virtual ICollection<DetIngresoSalida> DetIngresoSalida { get; }

    
    public virtual Proveedor Proveedor { get; set; }

    
    public virtual TipoTransaccion TipoTransaccion { get; set; }
}