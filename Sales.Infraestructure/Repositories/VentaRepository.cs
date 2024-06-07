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
}