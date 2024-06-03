using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class NumeroCorrelativoRepository : Repository<NumeroCorrelativo>, INumeroCorrelativoRepository
{
    private readonly SalesContext _context;

    public NumeroCorrelativoRepository(SalesContext context) : base(context)
    {
        this._context = context;
    }
}