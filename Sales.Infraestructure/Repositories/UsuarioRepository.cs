using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Common.Extensions;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Domain.Models;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;

namespace Sales.Infraestructure.Repositories;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    private readonly SalesContext _context;

    public UsuarioRepository(SalesContext context, IHttpContextAccessor httpContextAccessor) 
        : base(context, httpContextAccessor)
    {
        _context = context;
    }

    public async Task<List<UsuarioModel>> GetAllUsers()
    {
        var users = await (from us in _context.Usuarios
            where us.Eliminado == false
            select new UsuarioModel()
            {
                Id = us.Id,
                Nombre = us.Nombre,
                Correo = us.Correo,
                Telefono = us.Telefono,
                UrlFoto = us.UrlFoto,
                NombreFoto = us.Nombre,
                EsActivo = us.EsActivo,
                Eliminado = us.Eliminado,
                Clave = us.Clave
            }).ToListAsync();
        
        return users;
    }

    public async Task DeleteUser(int id)
    {
        Usuario? user = await this.Get(id);
        user!.FechaElimino = DateTime.Now;
        user!.Eliminado = true;
        await Update(user);
    }

    public override async Task Save(Usuario entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad usuario no puede ser nula.");
        
        if (await base.Exist(ct => ct.Nombre == entity.Nombre))
        {
            throw new UsuarioException("El usuario debe ser ùnico.");
        }
        
        await base.Save(entity);
    }

    public override async Task Save(List<Usuario> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado de usuarios no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new UsuarioException("La cantidad de usuarios debe ser mayor a cero.");
        }
        await base.Save(entities);
    }

    public override Task Update(Usuario entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad usuario no puede ser nula.");
        return base.Update(entity);
    }

    public override async Task Update(List<Usuario> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado de usuarios no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new UsuarioException("La cantidad de usuarios debe ser mayor a cero.");
        }
        await base.Update(entities);
    }

    public async Task<UsuarioModel?> GetByUserId(int id)
    {
        var user = await base.Get(id);

        if (user is null)
        {
            throw new UsuarioException("Usuario no encontrada");
        }

        return user.MapTo<UsuarioModel>();
    }
    
    public override string[] FullTextSearchColumns()
    {
        return [];
    }

    public override string[] FilterableColumns()
    {
        return [];
    }
}