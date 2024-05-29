using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Categori__3214EC076092C804");

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