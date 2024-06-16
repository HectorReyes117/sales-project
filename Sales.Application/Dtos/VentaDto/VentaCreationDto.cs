using Sales.Application.Dtos.DetalleVentaDto;
using Sales.Domain.Entities;

namespace Sales.Application.Dtos.VentaDto;

public class VentaCreationDto
{
    public string? NumeroVenta { get; set; }
    public int? IdTipoDocumentoVenta { get; set; }
    public int? IdUsuario { get; set; }
    public string? CocumentoCliente { get; set; }
    public string? NombreCliente { get; set; }
    public decimal? SubTotal { get; set; }
    public decimal? ImpuestoTotal { get; set; }
    public decimal? Total { get; set; }
    public ICollection<DetalleVentaCreationDto> DetalleVenta { get; set; } = new List<DetalleVentaCreationDto>();
}