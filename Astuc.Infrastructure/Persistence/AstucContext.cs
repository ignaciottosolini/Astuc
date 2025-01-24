using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIRL.Infrastructure.Data
{
    public class AstucContext : IdentityDbContext<ApplicationUser>
    {
        public AstucContext(DbContextOptions<AstucContext> options)
         : base(options)
        {
        }
        public DbSet<Evento> Eventos { get; set; } 
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<Membresia> Membresias { get;set; }
        public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<InsumoCarrito> InsumosCarritos { get; set; }
        public DbSet<InsumoPedido> InsumosPedidos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<Evento>().Property(e => e.Precio).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Insumo>().Property(i => i.Costo).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Insumo>().Property(i => i.PrecioVenta).HasColumnType("decimal(18,2)");

        }


    }


 

}
