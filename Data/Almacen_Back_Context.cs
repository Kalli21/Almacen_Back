using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Almacen_Back.Models;

namespace Almacen_Back.Data
{
    public class Almacen_Back_Context : DbContext
    {
        public Almacen_Back_Context (DbContextOptions<Almacen_Back_Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

        public DbSet<Almacen_Back.Models.Almacen>? Almacen { get; set; }

        public DbSet<Almacen_Back.Models.Articulo>? Articulo { get; set; }

        public DbSet<Almacen_Back.Models.Categoria>? Categoria { get; set; }

        public DbSet<Almacen_Back.Models.ControlStock>? ControlStock { get; set; }

        public DbSet<Almacen_Back.Models.DetIngresoSalida>? DetIngresoSalida { get; set; }

        public DbSet<Almacen_Back.Models.DetPedido>? DetPedido { get; set; }

        public DbSet<Almacen_Back.Models.GrupoAcceso>? GrupoAcceso { get; set; }

        public DbSet<Almacen_Back.Models.GrupoClave>? GrupoClave { get; set; }

        public DbSet<Almacen_Back.Models.IngresoSalida>? IngresoSalida { get; set; }

        public DbSet<Almacen_Back.Models.Pedido>? Pedido { get; set; }

        public DbSet<Almacen_Back.Models.Proveedor>? Proveedor { get; set; }

        public DbSet<Almacen_Back.Models.TipoTransaccion>? TipoTransaccion { get; set; }

        public DbSet<Almacen_Back.Models.UnidadMedida>? UnidadMedida { get; set; }

        public DbSet<Almacen_Back.Models.User>? User { get; set; }

    }
}
