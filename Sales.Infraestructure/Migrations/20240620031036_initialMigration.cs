using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioMod = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioElimino = table.Column<int>(type: "int", nullable: true),
                    FechaElimino = table.Column<DateTime>(type: "datetime", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__3214EC076092C804", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recurso = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Propiedad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Valor = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Configur__3214EC075A2FEE8B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    IdMenuPadre = table.Column<int>(type: "int", nullable: true),
                    Icono = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Controlador = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    PaginaAccion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioMod = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioElimino = table.Column<int>(type: "int", nullable: true),
                    FechaElimino = table.Column<DateTime>(type: "datetime", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Menu__3214EC0762612B1D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Menu__IdMenuPadr__5DCAEF64",
                        column: x => x.IdMenuPadre,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Negocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlLogo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    NombreLogo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NumeroDocumento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PorcentajeImpuesto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    SimboloMoneda = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioMod = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioElimino = table.Column<int>(type: "int", nullable: true),
                    FechaElimino = table.Column<DateTime>(type: "datetime", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Negocio__3214EC079C2355D1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumeroCorrelativo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UltimoNumero = table.Column<int>(type: "int", nullable: true),
                    CantidadDigitos = table.Column<int>(type: "int", nullable: true),
                    Gestion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NumeroCo__3214EC076981B485", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioMod = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioElimino = table.Column<int>(type: "int", nullable: true),
                    FechaElimino = table.Column<DateTime>(type: "datetime", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__3214EC074A1E2041", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentoVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioMod = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioElimino = table.Column<int>(type: "int", nullable: true),
                    FechaElimino = table.Column<DateTime>(type: "datetime", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoDocu__3214EC07FE1E4936", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoBarra = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Marca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    UrlImagen = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    NombreImagen = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioMod = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioElimino = table.Column<int>(type: "int", nullable: true),
                    FechaElimino = table.Column<DateTime>(type: "datetime", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__3214EC0746A13204", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Producto__IdCate__5EBF139D",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: true),
                    IdMenu = table.Column<int>(type: "int", nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioMod = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioElimino = table.Column<int>(type: "int", nullable: true),
                    FechaElimino = table.Column<DateTime>(type: "datetime", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RolMenu__3214EC07D687906D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__RolMenu__IdMenu__5FB337D6",
                        column: x => x.IdMenu,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__RolMenu__IdRol__60A75C0F",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdRol = table.Column<int>(type: "int", nullable: true),
                    UrlFoto = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    NombreFoto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Clave = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    FechaMod = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdUsuarioMod = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioElimino = table.Column<int>(type: "int", nullable: true),
                    FechaElimino = table.Column<DateTime>(type: "datetime", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__3214EC07CD08B65E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Usuario__IdRol__619B8048",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroVenta = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    IdTipoDocumentoVenta = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    CocumentoCliente = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    NombreCliente = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ImpuestoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdUsuarioCreacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venta__3214EC07A9C22441", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Venta__IdTipoDoc__628FA481",
                        column: x => x.IdTipoDocumentoVenta,
                        principalTable: "TipoDocumentoVenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Venta__IdUsuario__6383C8BA",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(type: "int", nullable: true),
                    IdProducto = table.Column<int>(type: "int", nullable: true),
                    MarcaProducto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DescripcionProducto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CategoriaProducto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleV__3214EC07A44F1E41", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DetalleVe__IdVen__5CD6CB2B",
                        column: x => x.IdVenta,
                        principalTable: "Venta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdVenta",
                table: "DetalleVenta",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_IdMenuPadre",
                table: "Menu",
                column: "IdMenuPadre");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_RolMenu_IdMenu",
                table: "RolMenu",
                column: "IdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_RolMenu_IdRol",
                table: "RolMenu",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuario",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdTipoDocumentoVenta",
                table: "Venta",
                column: "IdTipoDocumentoVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdUsuario",
                table: "Venta",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Negocio");

            migrationBuilder.DropTable(
                name: "NumeroCorrelativo");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "RolMenu");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "TipoDocumentoVenta");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
