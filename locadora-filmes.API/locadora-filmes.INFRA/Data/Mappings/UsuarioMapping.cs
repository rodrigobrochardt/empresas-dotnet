using locadora_filmes.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace locadora_filmes.INFRA.Data.Mappings {
    class UsuarioMapping{
        public UsuarioMapping(EntityTypeBuilder<Usuario> entity) {

            entity.ToTable(name: "usuario")
                .HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            entity.HasIndex(p => p.Email)
               .IsUnique();

            entity.Property(p => p.Cargo)
                .HasColumnName("cargo")
                .HasColumnType("int")
               .IsRequired();

            entity.Property(p => p.Auditoria)
               .HasColumnName("auditoria")
               .HasColumnType("varchar")
               .HasMaxLength(125)
               .IsRequired();

            entity.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            entity.Property(p => p.Senha)
                .HasColumnName("senha")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(p => p.Status)
                .HasColumnName("status")
                .HasColumnType("varchar")
                .HasMaxLength(2)
                .IsRequired();

            entity.HasMany(p => p.Voto)
                .WithOne(p => p.Usuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.UsuarioId)
                .IsRequired();

        }
    }
}
