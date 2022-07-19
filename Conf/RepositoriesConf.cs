﻿using Almacen_Back.Repository;
using Almacen_Back.Repository.Interfaces;

namespace Almacen_Back.Conf
{
    public class RepositoriesConf
    {
        public static void add(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();            
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IControlStockRepository, ControlStockRepository>();
            builder.Services.AddScoped<IDetIngresoRepository, DetIngresoRepository>();
            builder.Services.AddScoped<IDetIngresoSalidaRepository, DetIngresoSalidaRepository>();
            builder.Services.AddScoped<IDetPedidoRepository, DetPedidoRepository>();
            builder.Services.AddScoped<IDetSalidaRepository, DetSalidaRepository>();
            builder.Services.AddScoped<IGrupoAccesoRepository, GrupoAccesoRepository>();
            builder.Services.AddScoped<IGrupoClaveRepository, GrupoClaveRepository>();
            builder.Services.AddScoped<IIngresoRepository, IngresoRepository>();
            builder.Services.AddScoped<IIngresoSalidaRepository, IngresoSalidaRepository>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
            builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
            builder.Services.AddScoped<ISalidaRepository, SalidaRepository>();
            builder.Services.AddScoped<ITipoTransaccionRepository, TipoTransaccionRepository>();
            builder.Services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
