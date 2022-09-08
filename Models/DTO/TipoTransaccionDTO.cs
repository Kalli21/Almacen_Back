using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models.DTO;

public class TipoTransaccionDTO
{

    public TipoTransaccionDTO()
    {
        this.IngresoSalida = new HashSet<IngresoSalida>();
    }

    
    public string? cod_tipo_transaccion { get; set; }
    
    public string? descripcion { get; set; }
    
    public bool ingreso { get; set; }


    public virtual ICollection<IngresoSalida> IngresoSalida { get; }
}