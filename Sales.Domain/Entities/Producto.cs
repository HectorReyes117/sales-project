using System;
using System.Collections.Generic;
using Sales.Domain.Core;

namespace Sales.Domain.Entities;

public sealed class Producto : BaseEntity
{
    public int Id { get; set; }
    public string? CodigoBarra { get; set; }
    public string? Marca { get; set; }
    public string? Descripcion { get; set; }
    public int? IdCategoria { get; set; }
    public int? Stock { get; set; }
    public string? UrlImagen { get; set; }
    public string? NombreImagen { get; set; }
    public decimal? Precio { get; set; }
    public bool? EsActivo { get; set; }
    public Categoria? Categoria { get; set; }
}
