using Microsoft.EntityFrameworkCore;
using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.test.AbstractionsTests.Implementations;

public class DbInMemory : IDbInMemory
{
    public SalesContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<SalesContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        SalesContext context = new SalesContext(options);
        context.Database.EnsureCreated();
        return context;
    }
}