using System;
using System.Collections.Generic;
using Sales.Domain.Core;

namespace Sales.Domain.Entities;

public sealed class Rol : BaseEntity
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public bool? EsActivo { get; set; }
    public ICollection<RolMenu> RolMenus { get; set; } 
    public  ICollection<Usuario> Usuarios { get; set; }
}
