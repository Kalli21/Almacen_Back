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
    
    public long cod_clave { get; set; }
    
    public string? cod_proveedor { get; set; }
    
    public string? cod_almacen { get; set; }
    public string? Num_guia_ingreso { get; set; }
    [Required]
    public bool Importacion { get; set; }
    [Required]
    public System.DateTime Fecha_ingreso { get; set; }
    public string? Obs { get; set; }

    [ForeignKey("cod_almacen")]
    public virtual Almacen? Almacen { get; set; }
    [JsonIgnore]
    public virtual ICollection<DetIngreso> DetIngreso { get; }
    [ForeignKey("cod_clave")]
    public virtual GrupoClave? GrupoClave { get; set; }
    [ForeignKey("cod_proveedor")]
    public virtual Proveedor? Proveedor { get; set; }
}