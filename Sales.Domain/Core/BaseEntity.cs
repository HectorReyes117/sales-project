namespace Sales.Domain.Core;

public class BaseEntity : SecondBaseEntity
{
    public BaseEntity()
    {
        this.Eliminado = false;
    }
    public DateTime? FechaMod { get; set; }

    public int? IdUsuarioMod { get; set; }

    public int? IdUsuarioElimino { get; set; }

    public DateTime? FechaElimino { get; set; }

    public bool Eliminado { get; set; }
}