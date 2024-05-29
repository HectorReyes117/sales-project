using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class RolMenuConfiguration : IEntityTypeConfiguration<RolMenu>
{
    public void Configure(EntityTypeBuilder<RolMenu> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__RolMenu__3214EC07D687906D");

        builder.ToTable("RolMenu");

        builder.Property(e => e.FechaElimino).HasColumnType("datetime");
        builder.Property(e => e.FechaMod).HasColumnType("datetime");
        builder.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");

        builder.HasOne(d => d.IdMenuNavigation).WithMany(p => p.RolMenus)
            .HasForeignKey(d => d.IdMenu)
            .HasConstraintName("FK__RolMenu__IdMenu__5FB337D6");

        builder.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolMenus)
            .HasForeignKey(d => d.IdRol)
            .HasConstraintName("FK__RolMenu__IdRol__60A75C0F");
    }
}