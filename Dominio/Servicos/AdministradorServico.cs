
using MinhaApi.Dominio.DTOs;
using MinhaApi.Dominio.Entidades;
using MinhaApi.Infraestrutura.Db;
using System;
using System.Linq;
using MinhaApi.Dominio.Interfaces;

namespace MinhaApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
    }

    public Administrador? BuscaPorId(int id)
    {
        return _contexto.Administradores.Where(v => v.Id == id).FirstOrDefault();
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();

        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {

        var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm;

    }

    public List<Administrador> Todos(int? pagina)
    {
        var query = _contexto.Administradores.AsQueryable();


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