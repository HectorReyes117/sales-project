using Microsoft.AspNetCore.Http;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;

namespace Sales.Infraestructure.Repositories;

public class DetalleVentaRepository : Repository<DetalleVenta>, IDetalleVentaRepository
{
    private readonly SalesContext _context;

    public DetalleVentaRepository(SalesContext context, IHttpContextAccessor httpContextAccessor) 
        : base(context, httpContextAccessor)
    {
        _context = context;
    }
    
    public override async Task Save(DetalleVenta entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad no puede ser nula.");
        await base.Save(entity);
    }

    public override async Task Save(List<DetalleVenta> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado de detalles de venta no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new DetalleVentaException("La cantidad de detalles de venta debe ser mayor a cero.");
        }
        await base.Save(entities);
    }

    public override Task Update(DetalleVenta entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad no puede ser nula.");
        return base.Update(entity);
    }

    public override async Task Update(List<DetalleVenta> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado de detalles de venta no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new DetalleVentaException("La cantidad de detalles de venta debe ser mayor a cero.");
        }
        await base.Update(entities);
    }

    public override async Task<DetalleVenta?> Get(int id)
    {
        var detailSale = await base.Get(id);

        if (detailSale is null)
        {
            throw new DetalleVentaException("Detalle de venta no encontrado.");
        }

        return detailSale;
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