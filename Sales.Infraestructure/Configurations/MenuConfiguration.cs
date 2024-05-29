using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Menu__3214EC0762612B1D");

        builder.ToTable("Menu");

        builder.Property(e => e.Controlador)
            .HasMaxLength(30)
            .IsUnicode(false);
        builder.Property(e => e.Descripcion)
            .HasMaxLength(30)
            .IsUnicode(false);
        builder.Property(e => e.FechaElimino).HasColumnType("datetime");
        builder.Property(e => e.FechaMod).HasColumnType("datetime");
        builder.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.Icono)
            .HasMaxLength(30)
            .IsUnicode(false);
        builder.Property(e => e.PaginaAccion)
            .HasMaxLength(30)
            .IsUnicode(false);

        builder.HasOne(d => d.IdMenuPadreNavigation).WithMany(p => p.InverseIdMenuPadreNavigation)
            .HasForeignKey(d => d.IdMenuPadre)
            .HasConstraintName("FK__Menu__IdMenuPadr__5DCAEF64");
    }
}