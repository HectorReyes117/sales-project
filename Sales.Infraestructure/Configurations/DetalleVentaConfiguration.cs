using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__DetalleV__3214EC07A44F1E41");

        builder.Property(e => e.CategoriaProducto)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.DescripcionProducto)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.MarcaProducto)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        builder.Property(e => e.Total).HasColumnType("decimal(10, 2)");

        builder.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
            .HasForeignKey(d => d.IdVenta)
            .HasConstraintName("FK__DetalleVe__IdVen__5CD6CB2B");
    }
}