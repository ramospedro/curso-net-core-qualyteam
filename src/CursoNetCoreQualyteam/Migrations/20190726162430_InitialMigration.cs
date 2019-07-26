using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoNetCoreQualyteam.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Ingredientes = table.Column<string>(nullable: true),
                    Preparacao = table.Column<string>(nullable: true),
                    UrlDaImagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Receitas",
                columns: new[] { "Id", "Descricao", "Ingredientes", "Preparacao", "Titulo", "UrlDaImagem" },
                values: new object[] { new Guid("e52f21f0-72d6-4066-84c3-99359c2b3216"), "Um belo prato de feijão com arroz.", "Feijão, Arroz", "Misture.", "Feijão com Arroz", "rec.com/fjar" });

            migrationBuilder.InsertData(
                table: "Receitas",
                columns: new[] { "Id", "Descricao", "Ingredientes", "Preparacao", "Titulo", "UrlDaImagem" },
                values: new object[] { new Guid("7c76d64e-3524-4a0b-b0f2-79c6b22ff47a"), "Uma porção de batata", "Batata, Óleo, Sal", "Frite a bata", "Batatas Fritas", "rec.com/btfr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receitas");
        }
    }
}
