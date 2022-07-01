using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_CATEGORIA")]
public class Categoria
{

    public Categoria()
    {
        this.Articulo = new HashSet<Articulo>();
        this.Proveedor = new HashSet<Proveedor>();
    }

    [Key]
    public string Cod_categoria { get; set; }
    public string nom_categoria { get; set; }
    public string des_categoria { get; set; }
    public string Obs { get; set; }


    public virtual ICollection<Articulo> Articulo { get; set; }

    public virtual ICollection<Proveedor> Proveedor { get; set; }
}