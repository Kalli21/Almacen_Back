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
            builder.Services.AddScoped<IDetIngresoService, DetIngresoService>();
            builder.Services.AddScoped<IDetIngresoSalidaService, DetIngresoSalidaService>();
            builder.Services.AddScoped<IDetPedidoService, DetPedidoService>();
            builder.Services.AddScoped<IDetSalidaService, DetSalidaService>();
            builder.Services.AddScoped<IGrupoAccesoService, GrupoAccesoService>();
            builder.Services.AddScoped<IGrupoClaveService, GrupoClaveService>();
            builder.Services.AddScoped<IIngresoService, IngresoService>();
            builder.Services.AddScoped<IIngresoSalidaService, IngresoSalidaService>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();
            builder.Services.AddScoped<IProveedorService, ProveedorService>();
            builder.Services.AddScoped<ISalidaService, SalidaService>();
            builder.Services.AddScoped<ITipoTransaccionService, TipoTransaccionService>();
            builder.Services.AddScoped<IUnidadMedidaService, UnidadMedidaService>();
            builder.Services.AddScoped<IUserService, UserService>();
        
        }
    }
}
