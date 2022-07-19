using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using AutoMapper;

namespace Almacen_Back.Conf
{
    public class MappingConf
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AlmacenDTO, Almacen>();
                config.CreateMap<Almacen, AlmacenDTO>();

                config.CreateMap<ArticuloDTO, Articulo>();
                config.CreateMap<Articulo, ArticuloDTO>();

                config.CreateMap<CategoriaDTO, Categoria>();
                config.CreateMap<Categoria, CategoriaDTO>();

                config.CreateMap<ControlStockDTO, ControlStock>();
                config.CreateMap<ControlStock, ControlStockDTO>();

                config.CreateMap<DetIngresoDTO, DetIngreso>();
                config.CreateMap<DetIngreso, DetIngresoDTO>();

                config.CreateMap<DetIngresoSalidaDTO, DetIngresoSalida>();
                config.CreateMap<DetIngresoSalida, DetIngresoSalidaDTO>();

                config.CreateMap<DetPedidoDTO, DetPedido>();
                config.CreateMap<DetPedido, DetPedidoDTO>();

                config.CreateMap<DetSalidaDTO, DetSalida>();
                config.CreateMap<DetSalida, DetSalidaDTO>();

                config.CreateMap<GrupoAccesoDTO,GrupoAcceso>();
                config.CreateMap<GrupoAcceso, GrupoAccesoDTO>();

                config.CreateMap<GrupoClaveDTO, GrupoClave>();
                config.CreateMap<GrupoClave, GrupoClaveDTO>();

                config.CreateMap<IngresoDTO, Ingreso>();
                config.CreateMap<Ingreso, IngresoDTO>();

                config.CreateMap<IngresoSalidaDTO, IngresoSalida>();
                config.CreateMap<IngresoSalida, IngresoSalidaDTO>();

                config.CreateMap<PedidoDTO, Pedido>();
                config.CreateMap<Pedido, PedidoDTO>();

                config.CreateMap<ProveedorDTO, Proveedor>();
                config.CreateMap<Proveedor, ProveedorDTO>();

                config.CreateMap<SalidaDTO, Salida>();
                config.CreateMap<Salida, SalidaDTO>();

                config.CreateMap<TipoTransaccionDTO, TipoTransaccion>();
                config.CreateMap<TipoTransaccion, TipoTransaccionDTO>();

                config.CreateMap<UnidadMedidaDTO, UnidadMedida>();
                config.CreateMap<UnidadMedida, UnidadMedidaDTO>();

                config.CreateMap<UserDTO, User>();
                config.CreateMap<User, UserDTO>();
                
            });

            return mappingConfig;
        }
    }
}
