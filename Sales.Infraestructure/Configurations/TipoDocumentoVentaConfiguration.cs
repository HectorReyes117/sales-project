using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class TipoDocumentoVentaConfiguration : IEntityTypeConfiguration<TipoDocumentoVenta>
{
    public void Configure(EntityTypeBuilder<TipoDocumentoVenta> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__TipoDocu__3214EC07FE1E4936");

        builder.Property(e => e.Descripcion)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.FechaElimino).HasColumnType("datetime");
        builder.Property(e => e.FechaMod).HasColumnType("datetime");
        builder.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
    }
}