using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models.DTO;

public class IngresoDTO
{

    public IngresoDTO()
    {
        this.DetIngreso = new HashSet<DetIngreso>();
    }

    
    public long id_ingreso { get; set; }
    
    public long cod_clave { get; set; }
    
    public string cod_proveedor { get; set; }
    
    public string cod_almacen { get; set; }
    public string Num_guia_ingreso { get; set; }
    
    public bool Importacion { get; set; }
    
    public System.DateTime Fecha_ingreso { get; set; }
    public string Obs { get; set; }

    public virtual Almacen Almacen { get; set; }

    public virtual ICollection<DetIngreso> DetIngreso { get; }

    public virtual GrupoClave GrupoClave { get; set; }
    public virtual Proveedor Proveedor { get; set; }
}