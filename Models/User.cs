using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacen_Back.Models
{
    [Table("AL_USER")]
    public class User
    {
        
        [Key]
        public int Id { get; set; }
        [ForeignKey("cod_clave")]
        public bool activo { get; set; }
        public long cod_clave { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public virtual GrupoClave GrupoClave { get; set; }

    }
}
