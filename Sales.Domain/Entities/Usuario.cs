using System;
using System.Collections.Generic;
using Sales.Domain.Core;

namespace Sales.Domain.Entities;

public sealed class Usuario : BaseEntity
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public int? IdRol { get; set; }
    public string? UrlFoto { get; set; }
    public string? NombreFoto { get; set; }
    public string? Clave { get; set; }
    public bool EsActivo { get; set; }
    public Rol? Rol { get; set; }
    public ICollection<Venta> Venta { get; set; }
}
