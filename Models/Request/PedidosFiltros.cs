namespace Almacen_Back.Models.Request
{
    public class PedidosFiltros
    {       

        public bool? estado {get; set; }
        public DateTime? fechaIni {get; set; }
        public DateTime? fechaFin {get; set; }

    }
}