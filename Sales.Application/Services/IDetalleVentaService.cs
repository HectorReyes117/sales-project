using Sales.Application.Dtos.DetalleVentaDto;
using Sales.Domain.Entities;

namespace Sales.Application.Services;

public interface IDetalleVentaService
{
    Task Save(DetalleVentaCreationDto detalleVenta);
    Task Update(DetalleVentaUpdateDto detalleVenta);
    Task<DetalleVenta?> Get(int id);
    Task<List<DetalleVenta>> GetAll();
}
