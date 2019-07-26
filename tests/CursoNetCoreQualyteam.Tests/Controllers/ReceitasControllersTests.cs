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
        [Fact]
        public async void GetAll_DeveResponderComTodasAsReceitasCadastradas()
        {
            var options = new DbContextOptionsBuilder<ReceitasContext>()
                     .UseInMemoryDatabase("database")
                     .Options;
            var context = new ReceitasContext(options);
            context.AddRange(
                new Receita(1, "Feijão com Arroz", "Um belo prato de feijão com arroz.", "Feijão, Arroz", "Misture.", "rec.com/fjar"),
                new Receita(2, "Batatas Fritas", "Uma porção de batata", "Batata, Óleo, Sal", "Frite a bata", "rec.com/btfr"));
            await context.SaveChangesAsync();

            var controller = new ReceitasController(context);
            var receitas = await controller.GetAllAsync();

            receitas.Value.Should().HaveCount(2);

            receitas.Value.Should().BeEquivalentTo(new ReceitaViewModel[]
            {
                new ReceitaViewModel(1, "Feijão com Arroz", "Um belo prato de feijão com arroz.", "Feijão, Arroz", "Misture.", "rec.com/fjar"),
                new ReceitaViewModel(2, "Batatas Fritas", "Uma porção de batata", "Batata, Óleo, Sal", "Frite a bata", "rec.com/btfr")
            });
        }
    }
}
