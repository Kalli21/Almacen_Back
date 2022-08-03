using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models.DTO;


public class GrupoClaveDTO
{

    public GrupoClaveDTO()
    {
        this.Pedido = new HashSet<Pedido>();
    }

    
    public long cod_clave { get; set; }
    
    public string? Cod_funcionario { get; set; }
    
    public string? Cod_grupo { get; set; }
    public string? clave { get; set; }
    public string? apoya_a { get; set; }
    public string? ppp { get; set; }

    public virtual GrupoAcceso? GrupoAcceso { get; set; }
    
    public virtual ICollection<Pedido> Pedido { get; }
    
    public virtual User? user { get; set; }
}