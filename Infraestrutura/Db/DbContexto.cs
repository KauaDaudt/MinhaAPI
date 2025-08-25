using Microsoft.EntityFrameworkCore;
using MinhaApi.Dominio.Entidades;
using Microsoft.Extensions.Configuration;

namespace MinhaApi.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration? _configuracaoAppSettings;

        public DbContexto(DbContextOptions<DbContexto> options, IConfiguration? configuracaoAppSettings = null)
            : base(options)
        {
            _configuracaoAppSettings = configuracaoAppSettings;
        }

        public DbSet<Administrador> Administradores { get; set; } = default!;
        public DbSet<Veiculo> Veiculos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = 1,
                    Perfil = "Adm",
                    Senha = "123456",
                    Email = "administrador@teste.com",
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured && _configuracaoAppSettings != null)
            {
                var stringConexao = _configuracaoAppSettings.GetConnectionString("MySql");

                if (!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
                }
            }
        }
    }
}