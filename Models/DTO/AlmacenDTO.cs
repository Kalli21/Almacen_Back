using System.Text.Json.Serialization;

namespace Almacen_Back.Models.DTO
{
    public class AlmacenDTO
    {
        public AlmacenDTO()
        {
            this.ControlStock = new HashSet<ControlStock>();
            this.Ingreso = new HashSet<Ingreso>();
            this.IngresoSalida = new HashSet<IngresoSalida>();
            this.Pedido = new HashSet<Pedido>();
            this.Salida = new HashSet<Salida>();

            this.dir_almacen = "";
            this.tlf_almacen = "";
            this.Obs = "";

        }

        public string? cod_almacen { get; set; }


        public string? nom_almacen { get; set; }
        public string dir_almacen { get; set; }
        public string tlf_almacen { get; set; }
        public string? Obs { get; set; }

        
        public virtual ICollection<ControlStock> ControlStock { get; }
        
        public virtual ICollection<Ingreso> Ingreso { get; }
        
        public virtual ICollection<IngresoSalida> IngresoSalida { get; }
        
        public virtual ICollection<Pedido> Pedido { get; }
        
        public virtual ICollection<Salida> Salida { get; }
    }
}
