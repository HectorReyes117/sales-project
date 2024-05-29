using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Producto__3214EC0746A13204");

        builder.ToTable("Producto");

        builder.Property(e => e.CodigoBarra)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Descripcion)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.FechaElimino).HasColumnType("datetime");
        builder.Property(e => e.FechaMod).HasColumnType("datetime");
        builder.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.Marca)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.NombreImagen)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        builder.Property(e => e.UrlImagen)
            .HasMaxLength(500)
            .IsUnicode(false);

        builder.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
            .HasForeignKey(d => d.IdCategoria)
            .HasConstraintName("FK__Producto__IdCate__5EBF139D");
    }
}