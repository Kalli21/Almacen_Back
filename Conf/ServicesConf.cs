using Almacen_Back.Services;
using Almacen_Back.Services.Interfaces;

namespace Almacen_Back.Conf
{
    public class ServicesConf
    {
        public static void add(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAlmacenService, AlmacenService>();
            builder.Services.AddScoped<IArticuloService, ArticuloService>();            
            builder.Services.AddScoped<ICategoriaService, CategoriaService>();
            builder.Services.AddScoped<IControlStockService, ControlStockService>();
            builder.Services.AddScoped<IDetIngresoSalidaService, DetIngresoSalidaService>();
            builder.Services.AddScoped<IDetPedidoService, DetPedidoService>();
            builder.Services.AddScoped<IGrupoAccesoService, GrupoAccesoService>();
            builder.Services.AddScoped<IGrupoClaveService, GrupoClaveService>();
            builder.Services.AddScoped<IIngresoSalidaService, IngresoSalidaService>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();
            builder.Services.AddScoped<IProveedorService, ProveedorService>();
            builder.Services.AddScoped<ITipoTransaccionService, TipoTransaccionService>();
            builder.Services.AddScoped<IUnidadMedidaService, UnidadMedidaService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPr_Pg_PyService, Pr_Pg_PyService>();
        
        }
    }
}
