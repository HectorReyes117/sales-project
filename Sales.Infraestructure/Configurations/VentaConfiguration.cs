using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Venta__3214EC07A9C22441");

        builder.Property(e => e.CocumentoCliente)
            .HasMaxLength(10)
            .IsUnicode(false);
        builder.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.ImpuestoTotal).HasColumnType("decimal(10, 2)");
        builder.Property(e => e.NombreCliente)
            .HasMaxLength(20)
            .IsUnicode(false);
        builder.Property(e => e.NumeroVenta)
            .HasMaxLength(6)
            .IsUnicode(false);
        builder.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
        builder.Property(e => e.Total).HasColumnType("decimal(10, 2)");

        builder.HasOne(d => d.IdTipoDocumentoVentaNavigation).WithMany(p => p.Venta)
            .HasForeignKey(d => d.IdTipoDocumentoVenta)
            .HasConstraintName("FK__Venta__IdTipoDoc__628FA481");

        builder.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
            .HasForeignKey(d => d.IdUsuario)
            .HasConstraintName("FK__Venta__IdUsuario__6383C8BA");
    }
}