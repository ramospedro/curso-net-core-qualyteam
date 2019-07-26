using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoNetCoreQualyteam.Migrations
{
    public partial class SeedReceitasFake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Receitas",
                columns: new[] { "Id", "Descricao", "Ingredientes", "Preparacao", "Titulo", "UrlDaImagem" },
                values: new object[] { 1, "Um belo prato de feijão com arroz.", "Feijão, Arroz", "Misture.", "Feijão com Arroz", "rec.com/fjar" });

            migrationBuilder.InsertData(
                table: "Receitas",
                columns: new[] { "Id", "Descricao", "Ingredientes", "Preparacao", "Titulo", "UrlDaImagem" },
                values: new object[] { 2, "Uma porção de batata", "Batata, Óleo, Sal", "Frite a bata", "Batatas Fritas", "rec.com/btfr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Receitas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Receitas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
