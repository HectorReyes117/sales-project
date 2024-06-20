using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Repositories;
using Sales.Infraestructure.test.AbstractionsTests;
using Sales.Infraestructure.test.AbstractionsTests.Implementations;

namespace Sales.Infraestructure.test.Repositories;

public class ProductoRepositoryTest : IDisposable
{
    private readonly SalesContext _context;
    private readonly IProductoRepository _productoRepository;
    private Producto _producto;

    public ProductoRepositoryTest()
    {
        IDbInMemory context = new DbInMemory();
        _context = context.CreateContext();
        _productoRepository = new ProductoRepository(_context);
        _producto = new Producto()
        {
            CodigoBarra = "123456789",
            Marca = "Marca 1",
            Descripcion = "Producto 1",
            IdCategoria = 1,
            Stock = 10,
            Precio = 100.0m,
            EsActivo = true
        };
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenProductoIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _productoRepository.Save((Producto)null!));
    }

    [Fact]
    public async Task Save_ShouldSaveProducto_WhenProductoIsValid()
    {
        // Act
        await _productoRepository.Save(_producto);
        var savedProducto = await _context.Productos.FirstOrDefaultAsync(p => p.CodigoBarra == "123456789");

        // Assert
        Assert.NotNull(savedProducto);
        Assert.Equal("123456789", savedProducto.CodigoBarra);
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenProductoListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _productoRepository.Save((List<Producto>)null!));
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenProductoListIsEmpty()
    {
        // Arrange
        var emptyList = new List<Producto>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ProductException>(() => _productoRepository.Save(emptyList));
        Assert.Equal("La cantidad de productos debe ser mayor a cero.", exception.Message);
    }

    [Fact]
    public async Task Save_ShouldSaveProductos_WhenProductoListIsValid()
    {
        // Arrange
        var productos = new List<Producto>
        {
            _producto,
            new Producto()
            {
                CodigoBarra = "987654321",
                Marca = "Marca 2",
                Descripcion = "Producto 2",
                IdCategoria = 1,
                Stock = 5,
                Precio = 50.0m,
                EsActivo = true
            }
        };

        // Act
        await _productoRepository.Save(productos);
        var savedProductos = await _context.Productos.Where(p => p.IdCategoria == 1).ToListAsync();

        // Assert
        Assert.Equal(2, savedProductos.Count);
        Assert.Contains(savedProductos, p => p.CodigoBarra == "123456789");
        Assert.Contains(savedProductos, p => p.CodigoBarra == "987654321");
    }

    [Fact]
    public async Task GetProductById_ShouldThrowException_WhenProductoNotFound()
    {
        var exception = await Assert.ThrowsAsync<ProductException>(() => _productoRepository.GetProductById(999));
        Assert.Equal("Producto no encontrado.", exception.Message);
    }

    [Fact]
    public async Task GetProductById_ShouldReturnProducto_WhenProductoExists()
    {
        // Arrange
        Categoria categoria = new Categoria()
        {
            Descripcion = "Hola"
        };
        
        await _productoRepository.Save(_producto);
        await _context.Categoria.AddAsync(categoria);

        // Act
        var result = await _productoRepository.GetProductById(_producto.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(_producto.Descripcion, result.Descripcion);
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenProductoIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _productoRepository.Update((Producto)null!));
    }

    [Fact]
    public async Task Update_ShouldUpdateProducto_WhenProductoIsValid()
    {
        // Arrange
        await _productoRepository.Save(_producto);
        _producto.Descripcion = "Producto Actualizado";

        // Act
        await _productoRepository.Update(_producto);
        var updatedProducto = await _productoRepository.Get(_producto.Id);

        // Assert
        Assert.NotNull(updatedProducto);
        Assert.Equal("Producto Actualizado", updatedProducto.Descripcion);
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenProductoListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _productoRepository.Update((List<Producto>)null!));
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenProductoListIsEmpty()
    {
        // Arrange
        var emptyList = new List<Producto>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ProductException>(() => _productoRepository.Update(emptyList));
        Assert.Equal("La cantidad de productos debe ser mayor a cero.", exception.Message);
    }

    [Fact]
    public async Task Update_ShouldUpdateProductos_WhenProductoListIsValid()
    {
        // Arrange
        var productos = new List<Producto>
        {
            _producto,
            new Producto()
            {
                CodigoBarra = "987654321",
                Marca = "Marca 2",
                Descripcion = "Producto 2",
                IdCategoria = 1,
                Stock = 5,
                Precio = 50.0m,
                EsActivo = true
            }
        };

        await _productoRepository.Save(productos);

        productos[0].Descripcion = "Producto 1 Actualizado";
        productos[1].Descripcion = "Producto 2 Actualizado";

        // Act
        await _productoRepository.Update(productos);
        var updatedProductos = await _context.Productos.Where(p => productos.Select(prod => prod.Id).Contains(p.Id)).ToListAsync();

        // Assert
        Assert.Equal(2, updatedProductos.Count);
        Assert.Contains(updatedProductos, p => p.Descripcion == "Producto 1 Actualizado");
        Assert.Contains(updatedProductos, p => p.Descripcion == "Producto 2 Actualizado");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}