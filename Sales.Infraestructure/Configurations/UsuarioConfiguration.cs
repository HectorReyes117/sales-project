using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07CD08B65E");

        builder.ToTable("Usuario");

        builder.Property(e => e.Clave)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.Correo)
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
        builder.Property(e => e.NombreFoto)
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.Telefono)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.UrlFoto)
            .HasMaxLength(500)
            .IsUnicode(false);

        builder.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
            .HasForeignKey(d => d.IdRol)
            .HasConstraintName("FK__Usuario__IdRol__619B8048");
    }
}