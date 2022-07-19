using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_DET_SALIDA")]
public class DetSalida
{
    [Key]
    public long Id { get; set; }
    [ForeignKey("id_salida")]
    public long id_salida { get; set; }
    
    [ForeignKey("cod_articulo")]
    public long cod_articulo { get; set; }
    public Nullable<double> cant_articulo { get; set; }
    public Nullable<double> precio_unit_salida { get; set; }
    public string? Obs { get; set; }

    public virtual Articulo Articulo { get; set; }
    
    public virtual Salida Salida { get; set; }
}