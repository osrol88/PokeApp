using Microsoft.EntityFrameworkCore;
using PokeApiApp.Domain.Entity;

namespace PokeApiApp.Infrastructure
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options)
            : base(options) { }

        public DbSet<Pokemon> Pokemones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.ToTable("Pokemon");

                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedNever();
                entity.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Tipos).HasMaxLength(50);
                entity.Property(p => p.Altura);
                entity.Property(p => p.Peso);
                entity.Property(p => p.ImagenUrl).HasMaxLength(300); ;
                
            });
        }
    }
}
