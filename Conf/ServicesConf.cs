using Almacen_Back.Services;
using Almacen_Back.Services.Interfaces;

namespace Almacen_Back.Conf
{
    public class ServicesConf
    {
        public static void add(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAlmacenService, AlmacenService>();
        }
    }
}
