using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_UND_MEDIDA")]
public class UnidadMedida
{

    public UnidadMedida()
    {
        this.Articulo = new HashSet<Articulo>();
    }

    [Key]
    public string cod_und_medida { get; set; }
    [Required]
    public string des_und_medida { get; set; }
    public string Obs { get; set; }


    public virtual ICollection<Articulo> Articulo { get; }
}