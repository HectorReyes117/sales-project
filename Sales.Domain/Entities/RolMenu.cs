using System;
using System.Collections.Generic;
using Sales.Domain.Core;

namespace Sales.Domain.Entities;

public sealed class RolMenu : BaseEntity
{
    public int Id { get; set; }
    public int? IdRol { get; set; }
    public int? IdMenu { get; set; }

    public bool? EsActivo { get; set; }
    public Menu? IdMenuNavigation { get; set; }
    public Rol? IdRolNavigation { get; set; }
}
