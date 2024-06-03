using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Context;

public partial class SalesContext : DbContext
{
    public SalesContext()
    {
    }

    public SalesContext(DbContextOptions<SalesContext> options)
        : base(options)
    {
    }

    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Configuracion> Configuracions { get; set; }
    public DbSet<DetalleVenta> DetalleVenta { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Negocio> Negocios { get; set; }
    public DbSet<NumeroCorrelativo> NumeroCorrelativos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<RolMenu> RolMenus { get; set; }
    public DbSet<TipoDocumentoVenta> TipoDocumentoVenta { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Venta> Venta { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesContext).Assembly);
    }
}
