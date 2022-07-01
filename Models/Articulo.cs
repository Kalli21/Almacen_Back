using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_ARTICULO")]
public class Articulo
{

    public Articulo()
    {
        this.ControlStock = new HashSet<ControlStock>();
        this.DetIngreso = new HashSet<DetIngreso>();
        this.DetIngresoSalida = new HashSet<DetIngresoSalida>();
        this.DetPedido = new HashSet<DetPedido>();
        this.DetSalida = new HashSet<DetSalida>();
    }

    [Key]
    public long cod_articulo { get; set; }
    public string cod_und_medida { get; set; }
    public string Cod_categoria { get; set; }
    public string nom_articulo { get; set; }
    public string des_articulo { get; set; }
    public bool perecible { get; set; }
    public string ubicacion { get; set; }
    public bool estado { get; set; }
    public byte[] Imagen { get; set; }
    public Nullable<decimal> precio_promedio_ref { get; set; }
    public Nullable<decimal> precio_ultimo_ref { get; set; }
    public string Obs { get; set; }
    public Nullable<bool> visible { get; set; }

    [ForeignKey("Cod_categoria")]
    public virtual Categoria Categoria { get; set; }
    [ForeignKey("cod_und_medida")]
    public virtual UnidadMedida UnidadMedida { get; set; }
    
    public virtual ICollection<ControlStock> ControlStock { get; set; }

    public virtual ICollection<DetIngreso> DetIngreso { get; set; }

    public virtual ICollection<DetIngresoSalida> DetIngresoSalida { get; set; }

    public virtual ICollection<DetPedido> DetPedido { get; set; }

    public virtual ICollection<DetSalida> DetSalida { get; set; }
}