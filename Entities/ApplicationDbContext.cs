using Microsoft.EntityFrameworkCore;

namespace moviefinder.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<FilmeFavorito> FilmesFavoritos { get; set; }
    public DbSet<Ator> Atores { get; set; }
    public DbSet<AtorFavorito> AtoresFavoritos { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<GeneroFavorito> GenerosFavoritos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}