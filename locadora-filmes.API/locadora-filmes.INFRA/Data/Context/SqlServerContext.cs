using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.INFRA.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace locadora_filmes.INFRA.Data.Context {
    public class SqlServerContext : DbContext {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                String connectionString = @"Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            new UsuarioMapping(modelBuilder.Entity<Usuario>());
            new FilmeMapping(modelBuilder.Entity<Filme>());
            new VotoMapping(modelBuilder.Entity<Voto>());



        }
    }
}
