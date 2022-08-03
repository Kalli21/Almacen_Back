using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_GRUPO_CLAVE")]
public class GrupoClave
{

    public GrupoClave()
    {
        this.Pedido = new HashSet<Pedido>();
    }

    [Key]
    public long cod_clave { get; set; }
    [Required]
    public string? Cod_funcionario { get; set; }
    
    public string? Cod_grupo { get; set; }
    [Required]
    public string? clave { get; set; }
    public string? apoya_a { get; set; }
    public string? ppp { get; set; }
    [ForeignKey("Cod_grupo")]
    public virtual GrupoAcceso? GrupoAcceso { get; set; }
    [JsonIgnore]
    public virtual ICollection<Pedido> Pedido { get; }
    [JsonIgnore]
    public virtual User? user { get; } 
}