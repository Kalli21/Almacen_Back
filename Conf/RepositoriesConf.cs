using Almacen_Back.Repository;
using Almacen_Back.Repository.Interfaces;

namespace Almacen_Back.Conf
{
    public class RepositoriesConf
    {
        public static void add(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();
            
            // builder.Services.AddScoped<ICategoriaRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
            builder.Services.AddScoped<IAlmacenRepository, AlmacenRepository>();
        }
    }
}
