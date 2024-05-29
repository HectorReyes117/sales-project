using System;
using System.Collections.Generic;
using Sales.Domain.Core;

namespace Sales.Domain.Entities;

public sealed class Menu : BaseEntity
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public int? IdMenuPadre { get; set; }
    public string? Icono { get; set; }
    public string? Controlador { get; set; }
    public string? PaginaAccion { get; set; }

    public bool? EsActivo { get; set; }
    public Menu? IdMenuPadreNavigation { get; set; }
    public  ICollection<Menu> InverseIdMenuPadreNavigation { get; set; }
    public  ICollection<RolMenu> RolMenus { get; set; }
}
