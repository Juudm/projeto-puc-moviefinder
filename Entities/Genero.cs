using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviefinder.Entities;

[Table("Generos")]
public class Genero
{
    [Key]
    public int Id { get; set; }
    
    public int TheMovieDbId { get; set; }

    public string Nome { get; set; }
    
}