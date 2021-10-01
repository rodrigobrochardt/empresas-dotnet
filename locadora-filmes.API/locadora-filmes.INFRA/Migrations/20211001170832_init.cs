using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace locadora_filmes.INFRA.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "filme",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auditoria = table.Column<string>(type: "varchar(125)", maxLength: 125, nullable: false),
                    diretor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    titulo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    atores = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    lancamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    pontuacao = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    qtd_votos = table.Column<int>(type: "int", nullable: false),
                    sinopse = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filme", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auditoria = table.Column<string>(type: "varchar(125)", maxLength: 125, nullable: false),
                    cargo = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    senha = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "voto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auditoria = table.Column<string>(type: "varchar(125)", maxLength: 125, nullable: false),
                    filme_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    nota = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voto", x => x.id);
                    table.ForeignKey(
                        name: "FK_voto_filme_filme_id",
                        column: x => x.filme_id,
                        principalTable: "filme",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_voto_usuario_user_id",
                        column: x => x.user_id,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_email",
                table: "usuario",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_voto_filme_id",
                table: "voto",
                column: "filme_id");

            migrationBuilder.CreateIndex(
                name: "IX_voto_user_id",
                table: "voto",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "voto");

            migrationBuilder.DropTable(
                name: "filme");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
