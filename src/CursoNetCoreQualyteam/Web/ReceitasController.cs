using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoNetCoreQualyteam.Infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoNetCoreQualyteam.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly ReceitasContext _context;
        
        public ReceitasController(ReceitasContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceitaViewModel>>> GetAllAsync()
        {
            var todasAsReceitas = await _context.Receitas.ToArrayAsync();

            return todasAsReceitas
                    .Select(r => new ReceitaViewModel(r.Id, r.Titulo, r.Descricao, r.Ingredientes, r.Preparacao, r.UrlDaImagem))
                    .ToArray();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReceitaViewModel>> GetOneAsync(Guid id)
        {
            return null;
        }
    }

    public class ReceitaViewModel
    {
        public ReceitaViewModel(Guid id, string title, string description, string ingredients, string preparation, string imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            Ingredients = ingredients;
            Preparation = preparation;
            ImageUrl = imageUrl;
        }
        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Preparation { get; set; }
        public string ImageUrl { get; set; }
    }
}