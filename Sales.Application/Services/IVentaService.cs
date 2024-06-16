using Sales.Application.Dtos.VentaDto;
using Sales.Domain.Entities;

namespace Sales.Application.Services;

public interface IVentaService
{
    Task Save(VentaCreationDto venta);
    Task Update(VentaUpdateDto venta);
    Task<Venta?> Get(int id);
    Task<List<Venta>> GetAll();
}