using Sales.Infraestructure.Context;

namespace Sales.Infraestructure.test.AbstractionsTests;

public interface IDbInMemory
{
    SalesContext CreateContext();
}