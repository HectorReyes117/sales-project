namespace Sales.Domain.Core;

public class BaseEntity : SecondBaseEntity
{
    public DateTime? FechaMod { get; set; }

    public int? IdUsuarioMod { get; set; }

    public int? IdUsuarioElimino { get; set; }

    public DateTime? FechaElimino { get; set; }

    public bool Eliminado { get; set; }
}