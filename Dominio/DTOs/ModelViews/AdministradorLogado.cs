using MinhaApi.Dominio.Enuns;

namespace MinhaAPI.Dominio.ModelView;

public record AdministradorLogado
{

    public string Email { get; set; } = default!;

    public string Perfil { get; set; } = default!;

    public string Token { get; set; } = default!;

}