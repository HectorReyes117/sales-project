using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Domain.Models;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;

namespace Sales.Infraestructure.Repositories;

public class VentaRepository : Repository<Venta>, IVentaRepository
{
    private readonly SalesContext _context;

    public VentaRepository(SalesContext context) : base(context)
    {
        _context = context;
    }

    public async Task<VentaModel> GetSalesByUser(int userId)
    {
        var user = await (from us in _context.Usuarios
                join venta in _context.Venta on us.Id equals venta.IdUsuario
                where us.Id == userId
                select new VentaModel()
                {
                     Vendedor = us.Nombre,
                     NumeroVenta = us.Venta.Count()
                }
            ).FirstOrDefaultAsync();
        
        if (user is null)
        {
            throw new VentaException("El usuario no existe.");
        }

        return user;
    }
    
    public override async Task Save(Venta entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad no puede ser nula.");
        await base.Save(entity);
    }

    public override async Task Save(List<Venta> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new VentaException("La cantidad de ventas debe ser mayor a cero.");
        }
        await base.Save(entities);
    }

    public override Task Update(Venta entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La entidad no puede ser nula.");
        return base.Update(entity);
    }

    public override async Task Update(List<Venta> entities)
    {
        ArgumentNullException.ThrowIfNull(entities, "El listado no puede ser nulo.");
        
        if (!entities.Any())
        {
            throw new VentaException("La cantidad de ventas debe ser mayor a cero.");
        }
        await base.Update(entities);
    }

    public override async Task<Venta?> Get(int id)
    {
        var venta = await base.Get(id);

        if (venta is null)
        {
            throw new VentaException("Venta no encontrada");
        }

        return venta;
    }
}