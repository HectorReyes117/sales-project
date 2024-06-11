using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;

namespace Sales.Infraestructure.Repositories;

public class TipoDocumentoVentaRepository : Repository<TipoDocumentoVenta>, ITipoDocumentoVentaRepository
{
    private readonly SalesContext _context;

    public TipoDocumentoVentaRepository(SalesContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task Save(TipoDocumentoVenta entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad no puede ser nula.");
        
        if (await base.Exist(ct => ct.Descripcion == entity.Descripcion))
        {
            throw new TipoDocumentoVentaException("El documento debe ser ùnico.");
        }
        
        await base.Save(entity);
    }

    public override async Task Save(List<TipoDocumentoVenta> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado de documentos no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new TipoDocumentoVentaException("La cantidad de documentos debe ser mayor a cero.");
        }
        await base.Save(entities);
    }

    public override Task Update(TipoDocumentoVenta entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad no puede ser nula.");
        return base.Update(entity);
    }

    public override async Task Update(List< TipoDocumentoVenta> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado de documentos no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new TipoDocumentoVentaException("La cantidad de documentos debe ser mayor a cero.");
        }
        await base.Update(entities);
    }

    public override async Task<TipoDocumentoVenta?> Get(int id)
    {
        var document = await base.Get(id);

        if (document is null)
        {
            throw new TipoDocumentoVentaException("Documento no encontrado.");
        }

        return document;
    }
}