using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_TIPO_TRANSACCION")]
public class TipoTransaccion
{

    public TipoTransaccion()
    {
        this.IngresoSalida = new HashSet<IngresoSalida>();
    }

    [Key]
    public string cod_tipo_transaccion { get; set; }
    [Required]
    public string descripción { get; set; }
    [Required]
    public bool ingreso { get; set; }

    [JsonIgnore]
    public virtual ICollection<IngresoSalida> IngresoSalida { get; }
}