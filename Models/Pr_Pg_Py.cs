using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models
{
    [Table("Pr_Pg_Py")]
    public class Pr_Pg_Py
    {
        [Key]
        public int id_ppp { get; set; }
        public string? numero_ppp { get; set; }
        public string? cod_interno { get; set; }
        public string? Descripcion { get; set; }
        public Nullable<int> precedente { get; set; }
        public string? observaciones { get; set; }
        public string? obj_general { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public string? user_modificacion { get; set; }
        public string? obj_general2 { get; set; }

    }
}
