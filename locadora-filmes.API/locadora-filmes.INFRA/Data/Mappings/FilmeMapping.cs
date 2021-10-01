using locadora_filmes.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace locadora_filmes.INFRA.Data.Mappings {
    class FilmeMapping {
        public FilmeMapping(EntityTypeBuilder<Filme> entity) {

            entity.ToTable(name: "filme")
                .HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(p => p.Auditoria)
               .HasColumnName("auditoria")
               .HasColumnType("varchar")
               .HasMaxLength(125)
               .IsRequired();

            entity.Property(p => p.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(p => p.Diretor)
                .HasColumnName("diretor")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(p => p.Genero)
                .HasColumnName("genero")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(p => p.Atores)
                .HasColumnName("atores")
                .HasColumnType("nvarchar")
                .HasMaxLength(256);

            entity.Property(p => p.Status)
                .HasColumnName("status")
                .HasColumnType("varchar")
                .HasMaxLength(2)
                .IsRequired();

            entity.Property(p => p.Lancamento)
                .HasColumnName("lancamento")
                .HasColumnType("datetime");

            entity.Property(p => p.QtdVotos)
                .HasColumnName("qtd_votos")
                .HasColumnType("int");

            entity.Property(p => p.Pontuacao)
                .HasColumnName("pontuacao")
                .HasColumnType("decimal")
                .HasPrecision(8, 2);

            entity.Property(p => p.Sinopse)
                .HasColumnName("sinopse")
                .HasColumnType("nvarchar")
                .HasMaxLength(256);

            entity.HasMany(p => p.Voto)
               .WithOne(p => p.Filme)
               .OnDelete(DeleteBehavior.Restrict)
               .HasForeignKey(p => p.FilmeId)
               .IsRequired();
        }
    }
}
