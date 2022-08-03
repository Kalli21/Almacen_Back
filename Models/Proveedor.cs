using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_PROVEEDOR")]
public class Proveedor
{

    public Proveedor()
    {
        this.IngresoSalida = new HashSet<IngresoSalida>();
    }

    [Key]
    public string? cod_proveedor { get; set; }
    [Required]
    public string? razon_social { get; set; }
    
    public string? Cod_categoria { get; set; }
    public string? direccion { get; set; }
    public string? ciudad { get; set; }
    public string? pais { get; set; }
    public string? telefono { get; set; }
    public string? fax { get; set; }
    public string? web { get; set; }
    public string? Obs { get; set; }
    public string? contacto { get; set; }
    public string? beneficiario { get; set; }
    [Required]
    public string? activo { get; set; }
    public string? RUC { get; set; }
    public string? codigoPostal { get; set; }
    public string? Posicion { get; set; }
    public string? titulo { get; set; }
    public string? saludo { get; set; }

    [ForeignKey("Cod_categoria")]
    public virtual Categoria? Categoria { get; set; }
    [JsonIgnore]
    public virtual ICollection<IngresoSalida> IngresoSalida { get; }
}