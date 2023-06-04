namespace moviefinder.dto.genero;

public class GeneroDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public GeneroDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}