using Sales.Domain.Common.Extensions;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Domain.Models;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;

namespace Sales.Infraestructure.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    private readonly SalesContext _context;
    
    public CategoriaRepository(SalesContext context) : base(context)
    {
        this._context = context;
    }

    public override async Task Save(Categoria entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad categoria no puede ser nula.");
        
        if (await base.Exist(ct => ct.Descripcion == entity.Descripcion))
        {
            throw new CategoriaException("La categoria debe ser ùnica.");
        }
        
        await base.Save(entity);
    }

    public override async Task Save(List<Categoria> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado de categorias no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new CategoriaException("La cantidad de categorias debe ser mayor a cero.");
        }
        await base.Save(entities);
    }

    public override Task Update(Categoria entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad categoria no puede ser nula.");
        return base.Update(entity);
    }

    public override async Task Update(List<Categoria> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado de categorias no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new CategoriaException("La cantidad de categorias debe ser mayor a cero.");
        }
        await base.Update(entities);
    }

    public async Task<CategoriaModel?> GetCategoryById(int id)
    {
        var cat = await base.Get(id);

        if (cat is null)
        {
            throw new CategoriaException("Categoria no encontrada");
        }
        
        return cat.MapTo<CategoriaModel>();
    }
    
    public async Task DeleteCategory(int id)
    {
        Categoria? category = await this.Get(id);
        category!.FechaElimino = DateTime.Now;
        category!.Eliminado = true;
        await Update(category);
    }
}