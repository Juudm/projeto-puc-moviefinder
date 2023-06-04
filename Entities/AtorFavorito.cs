using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moviefinder.Entities;

[Table("AtoresFavoritos")]
public class AtorFavorito
{
    [Key]
    public int Id { get; set; }
        
    [ForeignKey("Atores")]
    public Ator IdAtor { get; set; }

    [ForeignKey("Usuarios")]
    public Usuario IdUsuario { get; set; }
    
}