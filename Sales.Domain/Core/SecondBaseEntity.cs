namespace Sales.Domain.Core;

public class SecondBaseEntity
{
    public SecondBaseEntity()
    {
        this.FechaRegistro = DateTime.Now;
    }
    public DateTime FechaRegistro { get; set; } 

    public int IdUsuarioCreacion { get; set; }
}