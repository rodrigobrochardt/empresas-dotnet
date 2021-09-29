using locadora_filmes.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.INFRA.Data.Mappings {
    class FilmeMapping {
        public FilmeMapping(EntityTypeBuilder<Filme> entity) {

            entity.ToTable(name: "Filme")
                .HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(p => p.Auditoria)
               .HasColumnName("Auditoria")
               .HasColumnType("varchar")
               .HasMaxLength(125)
               .IsRequired();

            entity.Property(p => p.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(p => p.Genero)
                .HasColumnName("Genero")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            entity.Property(p => p.Atores)
                .HasColumnName("Atores")
                .HasColumnType("varchar")
                .HasMaxLength(25);

            entity.Property(p => p.Status)
                .HasColumnName("Status")
                .HasColumnType("varchar")
                .HasMaxLength(2)
                .IsRequired();

            entity.Property(p => p.Lancamento)
                .HasColumnName("Lancamento")
                .HasColumnType("date");

            entity.Property(p => p.QtdVotos)
                .HasColumnName("QtdVotos")
                .HasColumnType("int");

            entity.Property(p => p.Pontuacao)
                .HasColumnName("Pontuacao")
                .HasColumnType("decimal")
                .HasPrecision(8, 1);

            entity.Property(p => p.Sinopse)
                .HasColumnName("Sinopse")
                .HasColumnType("varchar")
                .HasMaxLength(125);
        }
    }
}
