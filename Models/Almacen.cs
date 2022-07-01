using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models;

[Table("AL_ALMACEN")]
public class Almacen
{

    public Almacen()
    {
        this.ControlStock = new HashSet<ControlStock>();
        this.Ingreso = new HashSet<Ingreso>();
        this.IngresoSalida = new HashSet<IngresoSalida>();
        this.Pedido = new HashSet<Pedido>();
        this.Salida = new HashSet<Salida>();
    }
    
    [Key]
    public string cod_almacen { get; set; }
    [Required]
    public string nom_almacen { get; set; }
    
    public string dir_almacen { get; set; }
    public string tlf_almacen { get; set; }
    public string Obs { get; set; }


    public virtual ICollection<ControlStock> ControlStock { get; set; }

    public virtual ICollection<Ingreso> Ingreso { get; set; }

    public virtual ICollection<IngresoSalida> IngresoSalida { get; set; }

    public virtual ICollection<Pedido> Pedido { get; set; }

    public virtual ICollection<Salida> Salida { get; set; }
}