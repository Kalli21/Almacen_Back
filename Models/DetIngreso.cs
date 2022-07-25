using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_DET_INGRESO")]
public class DetIngreso
{
    [Key]
    public long Id { get; set; }
    
    public long cod_articulo { get; set; }
    
    public long id_ingreso { get; set; }
    public Nullable<double> cant_art_ingreso { get; set; }
    public Nullable<double> prec_unit_ingreso { get; set; }
    public string? Obs { get; set; }
    [ForeignKey("cod_articulo")]
    public virtual Articulo Articulo { get; set; }
    [ForeignKey("id_ingreso")]
    public virtual Ingreso Ingreso { get; set; }
}