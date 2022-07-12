using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models.DTO;

public class DetIngresoSalidaDTO
{
    
    public int Id { get; set; }
    
    public long id_transaccion { get; set; }
    
    public long cod_articulo { get; set; }
    public Nullable<double> cant_articulo { get; set; }
    public Nullable<double> costo_unitario { get; set; }
    public string Obs { get; set; }
    public Nullable<System.DateTime> fecha_vencimiento { get; set; }

    public virtual Articulo Articulo { get; set; }
 
    public virtual IngresoSalida IngresoSalida { get; set; }
}