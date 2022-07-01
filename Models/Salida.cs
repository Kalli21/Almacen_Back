using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_SALIDA")]
public class Salida
{

    public Salida()
    {
        this.DetSalida = new HashSet<DetSalida>();
        this.Pedido = new HashSet<Pedido>();
    }
    [Key]
    public long id_salida { get; set; }
    public long cod_clave { get; set; }
    public string cod_almacen { get; set; }
    public string num_guia_salida { get; set; }
    public bool despacho_pedido { get; set; }
    public bool donacion { get; set; }
    public bool venta { get; set; }
    public System.DateTime Fecha_salida { get; set; }
    public string Obs { get; set; }

    [ForeignKey("cod_almacen")]
    public virtual Almacen Almacen { get; set; }

    public virtual ICollection<DetSalida> DetSalida { get; set; }

    [ForeignKey("cod_clave")]
    public virtual GrupoClave GrupoClave { get; set; }

    public virtual ICollection<Pedido> Pedido { get; set; }
}