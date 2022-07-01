using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public string descripción { get; set; }
    public bool ingreso { get; set; }


    public virtual ICollection<IngresoSalida> IngresoSalida { get; set; }
}