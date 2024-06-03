using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class ConfiguracionRepository : Repository<Configuracion>, IConfiguracionRepository
{
    private readonly SalesContext _context;
    
    public ConfiguracionRepository(SalesContext context) : base(context)
    {
        this._context = context;
    }
}