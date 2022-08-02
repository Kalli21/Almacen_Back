using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models.DTO;

[Table("AL_UND_MEDIDA")]
public class UnidadMedidaDTO
{

    public UnidadMedidaDTO()
    {
        this.Articulo = new HashSet<Articulo>();
    }

    
    public string? cod_und_medida { get; set; }
    
    public string? des_und_medida { get; set; }
    public string? Obs { get; set; }


    public virtual ICollection<Articulo> Articulo { get; }
}