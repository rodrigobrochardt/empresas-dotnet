using locadora_filmes.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace locadora_filmes.INFRA.Data.Mappings {
    class VotoMapping {
        public VotoMapping(EntityTypeBuilder<Voto> entity) {

            entity.ToTable(name: "voto")
                .HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(p => p.Nota)
               .HasColumnName("nota")
               .HasColumnType("decimal")
               .HasPrecision(2, 1)
               .IsRequired();

            entity.Property(p => p.UsuarioId)
                .HasColumnName("user_id")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(p => p.FilmeId)
               .HasColumnName("filme_id")
               .HasColumnType("int")
               .IsRequired();

            entity.Property(p => p.Auditoria)
               .HasColumnName("auditoria")
               .HasColumnType("varchar")
               .HasMaxLength(125)
               .IsRequired();

            entity.Property(p => p.Status)
                .HasColumnName("status")
                .HasColumnType("varchar")
                .HasMaxLength(2)
                .IsRequired();

            entity.HasOne(p => p.Usuario)
               .WithMany(p => p.Voto)
               .OnDelete(DeleteBehavior.Restrict)
               .HasForeignKey(p => p.UsuarioId)
               .IsRequired();

            entity.HasOne(p => p.Filme)
               .WithMany(p => p.Voto)
               .OnDelete(DeleteBehavior.Restrict)
               .HasForeignKey(p => p.FilmeId)
               .IsRequired();
        }
    }
}
