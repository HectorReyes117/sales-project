using System;
using System.Collections.Generic;
using Sales.Domain.Core;

namespace Sales.Domain.Entities;

public sealed class Venta : SecondBaseEntity
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
    public ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
    public TipoDocumentoVenta? IdTipoDocumentoVentaNavigation { get; set; }
    public Usuario? IdUsuarioNavigation { get; set; }
}
