using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.INFRA.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.INFRA.Data.Context {
    public class SqlServerContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(@"Server=.\SQL2014;Database=locadora-filmes;Trusted_Connection=True;");
            }
        }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Administrador> Administradores { get; set; }
        DbSet<Filme> Filmes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            new UsuarioMapping(modelBuilder.Entity<Usuario>());
            new AdministradorMapping(modelBuilder.Entity<Administrador>());
            new FilmeMapping(modelBuilder.Entity<Filme>());


        }
    }
}
