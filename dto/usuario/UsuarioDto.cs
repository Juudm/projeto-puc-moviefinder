namespace moviefinder.dto.usuario;

public class UsuarioDto
{
    public string Email { get; set; }

    public string Senha { get; set; }

    public UsuarioDto(string email, string senha)
    {
        Email = email;
        Senha = senha;
    }
}