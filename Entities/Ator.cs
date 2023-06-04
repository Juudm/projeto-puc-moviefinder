using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviefinder.Entities;

[Table("Atores")]
public class Ator
{
    [Key]
    public int Id { get; set; }
    
    public int TheMovieDbId { get; set; }

    public string Nome { get; set; }
    
}