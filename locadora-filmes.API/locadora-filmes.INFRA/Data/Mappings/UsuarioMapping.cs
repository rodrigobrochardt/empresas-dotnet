using locadora_filmes.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.INFRA.Data.Mappings {
    class UsuarioMapping{
        public UsuarioMapping(EntityTypeBuilder<Usuario> entity) {

            entity.ToTable(name: "Usuario")
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

            entity.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            entity.Property(p => p.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            entity.Property(p => p.Status)
                .HasColumnName("Status")
                .HasColumnType("varchar")
                .HasMaxLength(2)
                .IsRequired();

        }
    }
}
