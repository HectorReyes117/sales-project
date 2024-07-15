using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sales.Application.Filters;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public abstract class Repository<TEntity> :Filterable<TEntity>, IRepository<TEntity> where TEntity : class
{
    private readonly SalesContext _context;
    private readonly DbSet<TEntity> _entities;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public Repository(SalesContext context, IHttpContextAccessor httpContextAccessor)
    {
        this._context = context;
        _httpContextAccessor = httpContextAccessor;
        _entities = context.Set<TEntity>();
    }
    
    public virtual async Task Save(TEntity entity)
    {
        _entities.Add(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Save(List<TEntity> entities)
    {
        _entities.AddRange(entities);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Update(TEntity entity)
    {
        _entities.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Update(List<TEntity> entities)
    {
        _entities.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<TEntity?> Get(int id)
    {
        return await _entities.FindAsync(id);
    }

    public virtual async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter)
    {
        if (filter is null)
        {
            return await _entities.ToListAsync();
        }
        return await _entities.Where(filter).ToListAsync();
    }

    public virtual async Task<bool> Exist(Expression<Func<TEntity, bool>> filter)
    {
        return await _entities.AnyAsync(filter);
    }

    public virtual IEnumerable<TEntity> WithFilter()
    {
        return Filter(_entities.AsQueryable(), _httpContextAccessor.HttpContext)
            .AsEnumerable();
    }
    
    
}