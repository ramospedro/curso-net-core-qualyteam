using System;
using Xunit;
using FluentAssertions;
using CursoNetCoreQualyteam.Web;
using CursoNetCoreQualyteam.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using CursoNetCoreQualyteam.Dominio;
using System.Linq;

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

        [Fact]
        public async void DeleteOneAsync_DeveDeletarAReceitaSolicitada()
        {
            var arrozComFeijao = new Receita("Feijão com Arroz", "Um belo prato de feijão com arroz.", "Feijão, Arroz", "Misture.", "rec.com/fjar");
            var batataFrita = new Receita("Batatas Fritas", "Uma porção de batata", "Batata, Óleo, Sal", "Frite a bata", "rec.com/btfr");

            var context = CreateTestContext();
            context.AddRange(arrozComFeijao, batataFrita);
            await context.SaveChangesAsync();
            
            var controller = new ReceitasController(context);
            await controller.DeleteOneAsync(arrozComFeijao.Id);
            
            var idsReceitas = await context.Receitas.Select(r => r.Id).ToArrayAsync();
            idsReceitas.Should().NotContain(arrozComFeijao.Id);
            
        }

        [Fact]
        public async void InsertAsync_DeveInserirAReceitaSolicitada()
        {
            var receitaParaInserir = new ReceitaViewModel(Guid.Empty, "lasanha", "bastante carboidrato", "massa, queijo", "assar", "rec.com/las");
            var context = CreateTestContext();

            var controller = new ReceitasController(context);
            var receitaInserida = await controller.InsertAsync(receitaParaInserir);
            
            var receitaDoBanco = context
                                    .Receitas
                                    .FirstOrDefault(r => r.Id == receitaInserida.Value.Id);

            receitaDoBanco.Should().NotBeNull();
            receitaDoBanco.Id.Should().NotBeEmpty();
            receitaDoBanco.Titulo.Should().Be(receitaParaInserir.Title);                   
        }

        [Fact]
        public async void UpdateAsync_DeveAtualizarAReceitaInserida()
        {
            var arrozPuro = new Receita("arroz", "branco", "só arroz", "cozinhar", "rec.com/arz");

            var context = CreateTestContext();
            context.Add(arrozPuro);
            await context.SaveChangesAsync();

            var controller = new ReceitasController(context);

            var arrozComFeijao =
                new ReceitaViewModel(
                    arrozPuro.Id, "arroz com feijão", "arroz branco e feijão preto", "só arroz e feijão", "cozinhar e misturar", "rec.com/aef");
            await controller.UpdateAsync(arrozComFeijao);

            context.Receitas
                .FirstOrDefault(r => r.Id == arrozComFeijao.Id)
                .Titulo.Should().Be(arrozComFeijao.Title);

        }
    }
}
