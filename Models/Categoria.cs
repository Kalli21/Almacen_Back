using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_CATEGORIA")]
public class Categoria
{

    public Categoria()
    {
        this.Articulo = new HashSet<Articulo>();
        this.Proveedor = new HashSet<Proveedor>();

        this.des_categoria = "";
        this.Obs = "";

    }

    [Key]
    public string? Cod_categoria { get; set; }
    [Required]
    public string? nom_categoria { get; set; }
    public string? des_categoria { get; set; }
    public string? Obs { get; set; }

    [JsonIgnore]
    public virtual ICollection<Articulo> Articulo { get; }
    [JsonIgnore]
    public virtual ICollection<Proveedor> Proveedor { get; }
}