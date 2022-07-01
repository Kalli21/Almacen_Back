using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_GRUPO_CLAVE")]
public class GrupoClave
{

    public GrupoClave()
    {
        this.Ingreso = new HashSet<Ingreso>();
        this.Pedido = new HashSet<Pedido>();
        this.Salida = new HashSet<Salida>();
    }

    [Key]
    public long cod_clave { get; set; }
    public string Cod_funcionario { get; set; }
    public string Cod_grupo { get; set; }
    public string clave { get; set; }
    public string apoya_a { get; set; }
    public string ppp { get; set; }

    [ForeignKey("Cod_grupo")]
    public virtual GrupoAcceso GrupoAcceso { get; set; }

    public virtual ICollection<Ingreso> Ingreso { get; set; }

    public virtual ICollection<Pedido> Pedido { get; set; }

    public virtual ICollection<Salida> Salida { get; set; }
}