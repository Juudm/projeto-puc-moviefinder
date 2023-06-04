using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviefinder.Entities;

[Table("GenerosFavoritos")]
public class GeneroFavorito
{
    [Key]
    public int Id { get; set; }
        
    [ForeignKey("Generos")]
    public Genero IdGenero { get; set; }

    [ForeignKey("Usuarios")]
    public Usuario IdUsuario { get; set; }
    
}