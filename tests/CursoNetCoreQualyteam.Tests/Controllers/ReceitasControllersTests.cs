using System;
using Xunit;
using FluentAssertions;
using CursoNetCoreQualyteam.Web;
using CursoNetCoreQualyteam.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using CursoNetCoreQualyteam.Dominio;

namespace CursoNetCoreQualyteam.Controllers.Tests
{
    public class ReceitasControllersTests
    {
        private ReceitasContext CreateTestContext()
        {
            var options = new DbContextOptionsBuilder<ReceitasContext>()
                     .UseInMemoryDatabase("database")
                     .Options;
            return new ReceitasContext(options);
        }

        [Fact]
        public async void GetAll_DeveResponderComTodasAsReceitasCadastradas()
        {
            var arrozComFeijao = new Receita("Feijão com Arroz", "Um belo prato de feijão com arroz.", "Feijão, Arroz", "Misture.", "rec.com/fjar");
            var batataFrita = new Receita("Batatas Fritas", "Uma porção de batata", "Batata, Óleo, Sal", "Frite a bata", "rec.com/btfr");

            var context = CreateTestContext();
            context.AddRange(arrozComFeijao, batataFrita);
            await context.SaveChangesAsync();

            var controller = new ReceitasController(context);
            var receitas = await controller.GetAllAsync();

            receitas.Value.Should().HaveCount(2);

            receitas.Value.Should().BeEquivalentTo(new ReceitaViewModel[]
            {
                new ReceitaViewModel(arrozComFeijao.Id, arrozComFeijao.Titulo, arrozComFeijao.Descricao,
                    arrozComFeijao.Ingredientes, arrozComFeijao.Preparacao, arrozComFeijao.UrlDaImagem),
                new ReceitaViewModel(batataFrita.Id, batataFrita.Titulo, batataFrita.Descricao,
                    batataFrita.Ingredientes, batataFrita.Preparacao, batataFrita.UrlDaImagem)
            });
        }

        [Fact]
        public async void GetOne_DeveResponderComAReceitaSolicitada()
        {
            var arrozComFeijao = new Receita("Feijão com Arroz", "Um belo prato de feijão com arroz.", "Feijão, Arroz", "Misture.", "rec.com/fjar");
            var batataFrita = new Receita("Batatas Fritas", "Uma porção de batata", "Batata, Óleo, Sal", "Frite a bata", "rec.com/btfr");

            var context = CreateTestContext();
            context.AddRange(arrozComFeijao, batataFrita);
            await context.SaveChangesAsync();

            var controller = new ReceitasController(context);
            var receita = await controller.GetOneAsync(batataFrita.Id);

            receita.Value.Should().BeEquivalentTo(
                new ReceitaViewModel(batataFrita.Id, batataFrita.Titulo, batataFrita.Descricao,
                    batataFrita.Ingredientes, batataFrita.Preparacao, batataFrita.UrlDaImagem)
            );
        }
    }
}
