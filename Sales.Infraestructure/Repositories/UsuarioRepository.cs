using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.Repositories;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    private readonly SalesContext _context;

    public UsuarioRepository(SalesContext context) : base(context)
    {
        _context = context;
    }
}