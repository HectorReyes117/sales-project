using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Rol__3214EC074A1E2041");

        builder.ToTable("Rol");

        builder.Property(e => e.Descripcion)
            .HasMaxLength(30)
            .IsUnicode(false);
        builder.Property(e => e.FechaElimino).HasColumnType("datetime");
        builder.Property(e => e.FechaMod).HasColumnType("datetime");
        builder.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
    }
}