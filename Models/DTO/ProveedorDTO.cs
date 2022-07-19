using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Almacen_Back.Models.DTO;

public class ProveedorDTO
{

    public ProveedorDTO()
    {
        this.Ingreso = new HashSet<Ingreso>();
        this.IngresoSalida = new HashSet<IngresoSalida>();
    }

    
    public string cod_proveedor { get; set; }
    
    public string razon_social { get; set; }
    public string Cod_categoria { get; set; }
    public string direccion { get; set; }
    public string ciudad { get; set; }
    public string pais { get; set; }
    public string telefono { get; set; }
    public string fax { get; set; }
    public string web { get; set; }
    public string Obs { get; set; }
    public string contacto { get; set; }
    public string beneficiario { get; set; }
    
    public string activo { get; set; }
    public string RUC { get; set; }
    public string codigoPostal { get; set; }
    public string Posicion { get; set; }
    public string titulo { get; set; }
    public string saludo { get; set; }

    public virtual Categoria Categoria { get; set; }
    
    public virtual ICollection<Ingreso> Ingreso { get; }
    
    public virtual ICollection<IngresoSalida> IngresoSalida { get; }
}