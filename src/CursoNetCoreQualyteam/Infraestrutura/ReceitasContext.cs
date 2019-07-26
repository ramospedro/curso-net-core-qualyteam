using CursoNetCoreQualyteam.Dominio;
using Microsoft.EntityFrameworkCore;

namespace CursoNetCoreQualyteam.Infraestrutura
{
    public class ReceitasContext: DbContext
    {
        public DbSet<Receita> Receitas { get; set; }
        public ReceitasContext(DbContextOptions<ReceitasContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Receita>()
                .HasData(
                    new Receita(1, "Feijão com Arroz", "Um belo prato de feijão com arroz.", "Feijão, Arroz", "Misture.", "rec.com/fjar"),
                    new Receita(2, "Batatas Fritas", "Uma porção de batata", "Batata, Óleo, Sal", "Frite a bata", "rec.com/btfr")
                );
                            
            base.OnModelCreating(modelBuilder);
        }
    }
}