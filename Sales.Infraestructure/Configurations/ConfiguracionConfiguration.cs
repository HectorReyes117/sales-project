using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class ConfiguracionConfiguration : IEntityTypeConfiguration<Configuracion>
{
    public void Configure(EntityTypeBuilder<Configuracion> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Configur__3214EC075A2FEE8B");

        builder.ToTable("Configuracion");

        builder.Property(e => e.Propiedad)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Recurso)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Valor)
            .HasMaxLength(60)
            .IsUnicode(false);
    }
}