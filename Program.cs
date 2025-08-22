var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Endpoint de teste GET
app.MapGet("/", () => "Olá pessoal, tudo bem?");

// Endpoint de login
app.MapPost("/login", (LoginDTO loginDTO) =>
{
   // Coloque o breakpoint nesta linha
   Console.WriteLine("Entrou no login"); // Confirma no terminal que o POST chegou

   if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
   {
      return Results.Ok("Login realizado com sucesso!");
   }
   else
   {
      return Results.Unauthorized();
   }
});

app.Run();

// DTO de login
public class LoginDTO
{
   public string Email { get; set; } = default!;
   public string Senha { get; set; } = default!;
}