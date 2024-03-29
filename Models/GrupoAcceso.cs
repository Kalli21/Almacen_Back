using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models;

[Table("AL_GRUPO_ACCESO")]
public class GrupoAcceso
{

    public GrupoAcceso()
    {
        this.GrupoClave = new HashSet<GrupoClave>();
    }

    [Key]
    public string? Cod_grupo { get; set; }
    public string? Descripcion { get; set; }
    [JsonIgnore]
    public virtual ICollection<GrupoClave> GrupoClave { get; }
}