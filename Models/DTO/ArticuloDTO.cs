using System.Text.Json.Serialization;

namespace Almacen_Back.Models.DTO;


public class ArticuloDTO
{

    
    public ArticuloDTO()
    {
        this.ControlStock = new HashSet<ControlStock>();
        this.DetIngreso = new HashSet<DetIngreso>();
        this.DetIngresoSalida = new HashSet<DetIngresoSalida>();
        this.DetPedido = new HashSet<DetPedido>();
        this.DetSalida = new HashSet<DetSalida>();

        this.des_articulo = "";
        this.ubicacion = "";
        this.Obs = "";
    }

    public long cod_articulo { get; set; }
    public string cod_und_medida { get; set; }

    public string Cod_categoria { get; set; }
    public string nom_articulo { get; set; }
    public string des_articulo { get; set; }
    public bool perecible { get; set; }
    public string ubicacion { get; set; }
    public bool estado { get; set; }
    public byte[]? Imagen { get; set; }
    public Nullable<double> precio_promedio_ref { get; set; }
    public Nullable<double> precio_ultimo_ref { get; set; }
    public string? Obs { get; set; }
    public Nullable<bool> visible { get; set; }
    public virtual Categoria Categoria { get; set; }
    public virtual UnidadMedida UnidadMedida { get; set; }
    
    public virtual ICollection<ControlStock> ControlStock { get; }
    
    public virtual ICollection<DetIngreso> DetIngreso { get; }
    
    public virtual ICollection<DetIngresoSalida> DetIngresoSalida { get; }
    
    public virtual ICollection<DetPedido> DetPedido { get; }
    
    public virtual ICollection<DetSalida> DetSalida { get; }
}