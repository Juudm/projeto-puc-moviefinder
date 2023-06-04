using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviefinder.Entities;

[Table("FilmesFavoritos")]
public class FilmeFavorito
{
    [Key]
    public int Id { get; set; }
        
    [ForeignKey("Filmes")]
    public Filme IdFilme { get; set; }

    [ForeignKey("Usuarios")]
    public Usuario IdUsuario { get; set; }
    
}