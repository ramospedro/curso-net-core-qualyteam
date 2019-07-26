using System;
using Xunit;
using FluentAssertions;

namespace CursoNetCoreQualyteam.Controllers.Tests
{
    public class ReceitasControllersTests
    {
        [Fact]
        public async void GetAll_DeveResponderComTodasAsReceitasCadastradas()
        {
            // insere receitas

            var controller = new ReceitasController();
            var receitas = await controller.GetAllAsync();
            receitas.Value.Should().BeEquivalentTo(new ReceitaViewModel[]
            {
                new ReceitaViewModel()
                {
                    Id = 1,
                    Title = "Feijão com Arroz",
                    Description = "Um belo prato de feijão com arroz que alimenta todo bom brasieiro.",
                    Ingredients = "Feijão, Arroz",
                    Preparation = "Misture o feijão com o arroz e pronto.",
                    ImageUrl = "fakeurl.com/feijaocomarroz"
                },
                new ReceitaViewModel()
                {
                    Id = 2,
                    Title = "Batatas Fritas",
                    Description = "Uma porção de bata melhor que a do Mc Donalds.",
                    Ingredients = "Batata, Óleo, Sal",
                    Preparation = "Frite a bata no óleo e adicione sal.",
                    ImageUrl = "fakeurl.com/batatasfritas"
                }
            });
        }
    }
}
