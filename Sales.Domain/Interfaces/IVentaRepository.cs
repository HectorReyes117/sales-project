using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.Domain.Interfaces;

public interface IVentaRepository : IRepository<Venta>
{
    Task<VentaModel> GetSalesByUser(int userId);
}