using MinhaApi.Dominio.Entidades;
using MinhaApi.Infraestrutura.Db;
using MinhaAPI.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MinhaApi.Dominio.Servicos;

public class VeiculoServico : IVeiculoServico
{
    private readonly DbContexto _contexto;
    public VeiculoServico(DbContexto contexto)
    {
        _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
    }

    public void Apagar(Veiculo veiculo)
    {
        _contexto.Veiculos.Remove(veiculo);
        _contexto.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        _contexto.SaveChanges();

    }

    public Veiculo? BuscaPorId(int id)
    {
        return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
    }

    public void Incluir(Veiculo veiculo)
    {
        _contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();

    }

    public List<Veiculo> Todos(int? pagina, string? nome = null, string? marca = null)
    {
        var query = _contexto.Veiculos.AsQueryable();

        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => EF.Functions.Like(v.Nome, $"%{nome}%"));
        }

        if (!string.IsNullOrEmpty(marca))
        {
            query = query.Where(v => v.Marca == marca);
        }


        if (pagina != null && pagina > 0)
        {
            query = query
                .OrderBy(v => v.Id)
                .Skip((pagina.Value - 1) * 10)
                .Take(10);
        }
        else
        {
            query = query.OrderBy(v => v.Id);
        }

        return query.ToList();
    }
}