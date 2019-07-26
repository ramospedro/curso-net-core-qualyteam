using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CursoNetCoreQualyteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        // GET api/receitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceitaViewModel>>> GetAllAsync()
        {
            
            return await Task.FromResult(new ReceitaViewModel[]
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

    public class ReceitaViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Preparation { get; set; }
        public string ImageUrl { get; set; }
    }
}