using System;
using System.Collections.Generic;

namespace Sales.Domain.Entities;

public sealed class Configuracion
{
    public short Id { get; set; }
    public string? Recurso { get; set; }
    public string? Propiedad { get; set; }
    public string? Valor { get; set; }
}
