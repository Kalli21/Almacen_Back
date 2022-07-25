namespace Almacen_Back.Models.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Token { get; set;}
        public bool activo { get; set; }
        public long cod_clave { get; set; } 
        public virtual GrupoClaveDTO GrupoClave { get; set; }

           
    }
}
