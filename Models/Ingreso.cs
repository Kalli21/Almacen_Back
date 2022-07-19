using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_INGRESO")]
public class Ingreso
{

    public Ingreso()
    {
        this.DetIngreso = new HashSet<DetIngreso>();
    }

    [Key]
    public long id_ingreso { get; set; }
    [ForeignKey("cod_clave")]
    public long cod_clave { get; set; }
    [ForeignKey("cod_proveedor")]
    public string cod_proveedor { get; set; }
    [ForeignKey("cod_almacen")]
    public string cod_almacen { get; set; }
    public string Num_guia_ingreso { get; set; }
    [Required]
    public bool Importacion { get; set; }
    [Required]
    public System.DateTime Fecha_ingreso { get; set; }
    public string Obs { get; set; }

    
    public virtual Almacen Almacen { get; set; }
    [JsonIgnore]
    public virtual ICollection<DetIngreso> DetIngreso { get; }
    
    public virtual GrupoClave GrupoClave { get; set; }
    
    public virtual Proveedor Proveedor { get; set; }
}