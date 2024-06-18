using Sales.WebApp.Models.DetalleVenta;

namespace Sales.WebApp.Models.Venta;

public class VentaUpdateViewModel
{
    public int Id { get; set; }
    public string? NumeroVenta { get; set; }
    public int? IdTipoDocumentoVenta { get; set; }
    public int? IdUsuario { get; set; }
    public string? CocumentoCliente { get; set; }
    public string? NombreCliente { get; set; }
    public decimal? SubTotal { get; set; }
    public decimal? ImpuestoTotal { get; set; }
    public decimal? Total { get; set; }
    public ICollection<DetalleVentaUpdateViewModel> DetalleVenta { get; set; } = new List<DetalleVentaUpdateViewModel>();
}