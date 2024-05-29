using System;
using System.Collections.Generic;
using Sales.Domain.Core;

namespace Sales.Domain.Entities;

public sealed class TipoDocumentoVenta : BaseEntity
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public bool? EsActivo { get; set; }
    public ICollection<Venta> Venta { get; set; }
}
