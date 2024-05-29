using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class NumeroCorrelativoConfiguration : IEntityTypeConfiguration<NumeroCorrelativo>
{
    public void Configure(EntityTypeBuilder<NumeroCorrelativo> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__NumeroCo__3214EC076981B485");

        builder.ToTable("NumeroCorrelativo");

        builder.Property(e => e.FechaActualizacion).HasColumnType("datetime");
        builder.Property(e => e.Gestion)
            .HasMaxLength(100)
            .IsUnicode(false);
    }
}