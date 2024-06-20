﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sales.Infraestructure.Context;

#nullable disable

namespace Sales.Infraestructure.Migrations
{
    [DbContext(typeof(SalesContext))]
    [Migration("20240620031036_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sales.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<bool?>("EsActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaElimino")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaMod")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioElimino")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Categori__3214EC076092C804");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Configuracion", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Propiedad")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Recurso")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Valor")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id")
                        .HasName("PK__Configur__3214EC075A2FEE8B");

                    b.ToTable("Configuracion", (string)null);
                });

            modelBuilder.Entity("Sales.Domain.Entities.DetalleVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CategoriaProducto")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DescripcionProducto")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int?>("IdVenta")
                        .HasColumnType("int");

                    b.Property<string>("MarcaProducto")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id")
                        .HasName("PK__DetalleV__3214EC07A44F1E41");

                    b.HasIndex("IdVenta");

                    b.ToTable("DetalleVenta");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Controlador")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<bool?>("EsActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaElimino")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaMod")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Icono")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("IdMenuPadre")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioElimino")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioMod")
                        .HasColumnType("int");

                    b.Property<string>("PaginaAccion")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id")
                        .HasName("PK__Menu__3214EC0762612B1D");

                    b.HasIndex("IdMenuPadre");

                    b.ToTable("Menu", (string)null);
                });

            modelBuilder.Entity("Sales.Domain.Entities.Negocio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaElimino")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaMod")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioElimino")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioMod")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreLogo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NumeroDocumento")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("PorcentajeImpuesto")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("SimboloMoneda")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UrlLogo")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id")
                        .HasName("PK__Negocio__3214EC079C2355D1");

                    b.ToTable("Negocio", (string)null);
                });

            modelBuilder.Entity("Sales.Domain.Entities.NumeroCorrelativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CantidadDigitos")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<string>("Gestion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("UltimoNumero")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__NumeroCo__3214EC076981B485");

                    b.ToTable("NumeroCorrelativo", (string)null);
                });

            modelBuilder.Entity("Sales.Domain.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoBarra")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<bool?>("EsActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaElimino")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaMod")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioElimino")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioMod")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreImagen")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("UrlImagen")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id")
                        .HasName("PK__Producto__3214EC0746A13204");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Sales.Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<bool?>("EsActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaElimino")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaMod")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioElimino")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Rol__3214EC074A1E2041");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Sales.Domain.Entities.RolMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<bool?>("EsActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaElimino")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaMod")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdMenu")
                        .HasColumnType("int");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioElimino")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__RolMenu__3214EC07D687906D");

                    b.HasIndex("IdMenu");

                    b.HasIndex("IdRol");

                    b.ToTable("RolMenu", (string)null);
                });

            modelBuilder.Entity("Sales.Domain.Entities.TipoDocumentoVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<bool?>("EsActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaElimino")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaMod")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioElimino")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__TipoDocu__3214EC07FE1E4936");

                    b.ToTable("TipoDocumentoVenta");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Clave")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<bool>("EsActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaElimino")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaMod")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioElimino")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioMod")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreFoto")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UrlFoto")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id")
                        .HasName("PK__Usuario__3214EC07CD08B65E");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Sales.Domain.Entities.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CocumentoCliente")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdTipoDocumentoVenta")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<decimal?>("ImpuestoTotal")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("NombreCliente")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NumeroVenta")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.Property<decimal?>("SubTotal")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id")
                        .HasName("PK__Venta__3214EC07A9C22441");

                    b.HasIndex("IdTipoDocumentoVenta");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("Sales.Domain.Entities.DetalleVenta", b =>
                {
                    b.HasOne("Sales.Domain.Entities.Venta", "Venta")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("IdVenta")
                        .HasConstraintName("FK__DetalleVe__IdVen__5CD6CB2B");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Menu", b =>
                {
                    b.HasOne("Sales.Domain.Entities.Menu", "IdMenuPadreNavigation")
                        .WithMany("InverseIdMenuPadreNavigation")
                        .HasForeignKey("IdMenuPadre")
                        .HasConstraintName("FK__Menu__IdMenuPadr__5DCAEF64");

                    b.Navigation("IdMenuPadreNavigation");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Producto", b =>
                {
                    b.HasOne("Sales.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("FK__Producto__IdCate__5EBF139D");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Sales.Domain.Entities.RolMenu", b =>
                {
                    b.HasOne("Sales.Domain.Entities.Menu", "IdMenuNavigation")
                        .WithMany("RolMenus")
                        .HasForeignKey("IdMenu")
                        .HasConstraintName("FK__RolMenu__IdMenu__5FB337D6");

                    b.HasOne("Sales.Domain.Entities.Rol", "IdRolNavigation")
                        .WithMany("RolMenus")
                        .HasForeignKey("IdRol")
                        .HasConstraintName("FK__RolMenu__IdRol__60A75C0F");

                    b.Navigation("IdMenuNavigation");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Sales.Domain.Entities.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .HasConstraintName("FK__Usuario__IdRol__619B8048");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Venta", b =>
                {
                    b.HasOne("Sales.Domain.Entities.TipoDocumentoVenta", "TipoDocumentoVenta")
                        .WithMany("Venta")
                        .HasForeignKey("IdTipoDocumentoVenta")
                        .HasConstraintName("FK__Venta__IdTipoDoc__628FA481");

                    b.HasOne("Sales.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Venta")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Venta__IdUsuario__6383C8BA");

                    b.Navigation("TipoDocumentoVenta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Menu", b =>
                {
                    b.Navigation("InverseIdMenuPadreNavigation");

                    b.Navigation("RolMenus");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Rol", b =>
                {
                    b.Navigation("RolMenus");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Sales.Domain.Entities.TipoDocumentoVenta", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Sales.Domain.Entities.Venta", b =>
                {
                    b.Navigation("DetalleVenta");
                });
#pragma warning restore 612, 618
        }
    }
}