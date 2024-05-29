using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class NegocioConfiguration : IEntityTypeConfiguration<Negocio>
{
    public void Configure(EntityTypeBuilder<Negocio> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Negocio__3214EC079C2355D1");

        builder.ToTable("Negocio");

        builder.Property(e => e.Correo)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Direccion)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.FechaElimino).HasColumnType("datetime");
        builder.Property(e => e.FechaMod).HasColumnType("datetime");
        builder.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.Nombre)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.NombreLogo)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.NumeroDocumento)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.PorcentajeImpuesto).HasColumnType("decimal(10, 2)");
        builder.Property(e => e.SimboloMoneda)
            .HasMaxLength(5)
            .IsUnicode(false);
        builder.Property(e => e.Telefono)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.UrlLogo)
            .HasMaxLength(500)
            .IsUnicode(false);
    }
}