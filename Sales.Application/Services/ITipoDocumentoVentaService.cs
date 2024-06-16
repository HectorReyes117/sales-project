using Sales.Application.Dtos.TipoDocumentoVentaDto;
using Sales.Domain.Entities;

namespace Sales.Application.Services;

public interface ITipoDocumentoVentaService
{
    Task Save(TipoDocumentoVentaCreationDto tipoDocumentoVentaCreation);
    Task Update(TipoDocumentoVentaUpdateDto tipoDocumentoVentaCreation);
    Task<TipoDocumentoVenta?> Get(int id);
    Task<List<TipoDocumentoVenta>> GetAll();
}