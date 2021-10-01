﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using locadora_filmes.INFRA.Data.Context;

namespace locadora_filmes.INFRA.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("locadora_filmes.DOMAIN.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Atores")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("atores");

                    b.Property<string>("Auditoria")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("varchar(125)")
                        .HasColumnName("auditoria");

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("diretor");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("genero");

                    b.Property<DateTime>("Lancamento")
                        .HasColumnType("datetime")
                        .HasColumnName("lancamento");

                    b.Property<decimal>("Pontuacao")
                        .HasPrecision(8, 1)
                        .HasColumnType("decimal(8,1)")
                        .HasColumnName("pontuacao");

                    b.Property<int>("QtdVotos")
                        .HasColumnType("int")
                        .HasColumnName("qtd_votos");

                    b.Property<string>("Sinopse")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("sinopse");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("status");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("titulo");

                    b.HasKey("Id");

                    b.ToTable("filme");
                });

            modelBuilder.Entity("locadora_filmes.DOMAIN.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Auditoria")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("varchar(125)")
                        .HasColumnName("auditoria");

                    b.Property<int>("Cargo")
                        .HasColumnType("int")
                        .HasColumnName("cargo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("senha");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("locadora_filmes.DOMAIN.Entities.Voto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Auditoria")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("varchar(125)")
                        .HasColumnName("auditoria");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int")
                        .HasColumnName("filme_id");

                    b.Property<decimal>("Nota")
                        .HasPrecision(2, 1)
                        .HasColumnType("decimal(2,1)")
                        .HasColumnName("nota");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("status");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("FilmeId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("voto");
                });

            modelBuilder.Entity("locadora_filmes.DOMAIN.Entities.Voto", b =>
                {
                    b.HasOne("locadora_filmes.DOMAIN.Entities.Filme", "Filme")
                        .WithMany("Voto")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("locadora_filmes.DOMAIN.Entities.Usuario", "Usuario")
                        .WithMany("Voto")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("locadora_filmes.DOMAIN.Entities.Filme", b =>
                {
                    b.Navigation("Voto");
                });

            modelBuilder.Entity("locadora_filmes.DOMAIN.Entities.Usuario", b =>
                {
                    b.Navigation("Voto");
                });
#pragma warning restore 612, 618
        }
    }
}