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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HECTORREYES\\SQLEXPRESS;Database=Sales;Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesContext).Assembly);
    }
}
