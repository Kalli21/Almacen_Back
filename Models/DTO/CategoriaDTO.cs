
using System.Text.Json.Serialization;

namespace Almacen_Back.Models.DTO;

public class CategoriaDTO
{

    public CategoriaDTO()
    {
        this.Articulo = new HashSet<Articulo>();
        this.Proveedor = new HashSet<Proveedor>();

        this.des_categoria = "";
        this.Obs = "";

    }

    
    public string Cod_categoria { get; set; }
    
    public string nom_categoria { get; set; }
    public string des_categoria { get; set; }
    public string Obs { get; set; }

    
    public virtual ICollection<Articulo> Articulo { get; }
    
    public virtual ICollection<Proveedor> Proveedor { get; }
}