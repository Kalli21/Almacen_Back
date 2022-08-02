using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models.DTO;

public class GrupoAccesoDTO
{

    public GrupoAccesoDTO()
    {
        this.GrupoClave = new HashSet<GrupoClave>();
    }

    
    public string? Cod_grupo { get; set; }
    public string? Descripcion { get; set; }
    
     public virtual ICollection<GrupoClave> GrupoClave { get; }
}