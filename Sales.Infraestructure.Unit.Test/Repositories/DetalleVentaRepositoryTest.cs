using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Repositories;
using Sales.Infraestructure.test.AbstractionsTests;
using Sales.Infraestructure.test.AbstractionsTests.Implementations;

namespace Sales.Infraestructure.test.Repositories;

public class DetalleVentaRepositoryTest : IDisposable
{
    private readonly SalesContext _context;
    private readonly IDetalleVentaRepository _detalleVentaRepository;
    private DetalleVenta _detalleVenta;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public DetalleVentaRepositoryTest()
    {
        IDbInMemory context = new DbInMemory();
        _context = context.CreateContext();
        _detalleVentaRepository = new DetalleVentaRepository(_context, _httpContextAccessor);
        _detalleVenta = new DetalleVenta()
        {
            IdVenta = 1,
            IdProducto = 1,
            MarcaProducto = "Marca 1",
            DescripcionProducto = "Producto 1",
            CategoriaProducto = "Categoria 1",
            Cantidad = 2,
            Precio = 100,
            Total = 100
        };
    }
    
    [Fact]
    public async Task Save_ShouldThrowException_WhenDetalleVentaIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _detalleVentaRepository.Save((DetalleVenta)null));
    }

    [Fact]
    public async Task Save_ShouldSaveDetalleVenta_WhenDetalleVentaIsValid()
    {
        // Act
        await _detalleVentaRepository.Save(_detalleVenta);
        var savedDetalleVenta = await _context.DetalleVenta.FirstOrDefaultAsync(dv => dv.CategoriaProducto == "Categoria 1");
    
        // Assert
        Assert.NotNull(savedDetalleVenta);
        Assert.Equal("Categoria 1", savedDetalleVenta.CategoriaProducto);
    }
    
    [Fact]
    public async Task Save_ShouldThrowException_WhenDetalleVentaListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _detalleVentaRepository.Save((List<DetalleVenta>)null!));
    }
    
    
    [Fact]
    public async Task Save_ShouldThrowException_WhenDetalleVentaListIsEmpty()
    {
        // Arrange
        var emptyList = new List<DetalleVenta>();
    
        // Act & Assert
        var exception = await Assert.ThrowsAsync<DetalleVentaException>(() => _detalleVentaRepository.Save(emptyList));
        Assert.Equal("La cantidad de detalles de venta debe ser mayor a cero.", exception.Message);
    }
    
    [Fact]
    public async Task Save_ShouldSaveDetalleVentas_WhenDetalleVentaListIsValid()
    {
        // Arrange
        var detalleVentas = new List<DetalleVenta>
        {
            _detalleVenta,
            new DetalleVenta()
            {
                IdVenta = 1,
                IdProducto = 1,
                MarcaProducto = "Marca 1",
                DescripcionProducto = "Producto 1",
                CategoriaProducto = "Categoria 1",
                Cantidad = 2,
                Precio = 100,
                Total = 100
            }
        };
    
        // Act
        await _detalleVentaRepository.Save(detalleVentas);
        var savedDetalleVentas = await _context.DetalleVenta
            .Where(dv => dv.IdVenta == 1)
            .ToListAsync();
    
        // Assert
        Assert.Equal(2, savedDetalleVentas.Count);
        Assert.Contains(savedDetalleVentas, dv => dv.IdVenta == 1);
        Assert.Contains(savedDetalleVentas, dv => dv.IdVenta == 1);
    }
    
    [Fact]
    public async Task Get_ShouldThrowException_WhenDetalleVentaNotFound()
    {
        var exception = await Assert.ThrowsAsync<DetalleVentaException>(() => _detalleVentaRepository.Get(999));
        Assert.Equal("Detalle de venta no encontrado.", exception.Message);
    }
    
    [Fact]
    public async Task Get_ShouldReturnDetalleVenta_WhenDetalleVentaExists()
    {
        // Arrange
        await _detalleVentaRepository.Save(_detalleVenta);
    
        // Act
        var result = await _detalleVentaRepository.Get(_detalleVenta.Id);
    
        // Assert
        Assert.NotNull(result);
        Assert.Equal(_detalleVenta.DescripcionProducto, result.DescripcionProducto);
    }
    
    [Fact]
    public async Task Update_ShouldThrowException_WhenDetalleVentaIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _detalleVentaRepository.Update((DetalleVenta)null!));
    }
    
    [Fact]
    public async Task Update_ShouldUpdateDetalleVenta_WhenDetalleVentaIsValid()
    {
        // Arrange
        await _detalleVentaRepository.Save(_detalleVenta);
        _detalleVenta.CategoriaProducto = "Categoria 2";
    
        // Act
        await _detalleVentaRepository.Update(_detalleVenta);
        var updatedDetalleVenta = await _detalleVentaRepository.Get(_detalleVenta.Id);
    
        // Assert
        Assert.NotNull(updatedDetalleVenta);
        Assert.Equal("Categoria 2", updatedDetalleVenta.CategoriaProducto);
    }
    
    [Fact]
    public async Task Update_ShouldThrowException_WhenDetalleVentaListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _detalleVentaRepository.Update((List<DetalleVenta>)null!));
    }
    
    [Fact]
    public async Task Update_ShouldThrowException_WhenDetalleVentaListIsEmpty()
    {
        // Arrange
        var emptyList = new List<DetalleVenta>();
    
        // Act & Assert
        var exception = await Assert.ThrowsAsync<DetalleVentaException>(() => _detalleVentaRepository.Update(emptyList));
        Assert.Equal("La cantidad de detalles de venta debe ser mayor a cero.", exception.Message);
    }
    
    [Fact]
    public async Task Update_ShouldUpdateDetalleVentas_WhenDetalleVentaListIsValid()
    {
        // Arrange
        var detalleVentas = new List<DetalleVenta>
        {
            _detalleVenta,
            new DetalleVenta()
            {
                IdVenta = 1,
                IdProducto = 1,
                MarcaProducto = "Marca 1",
                DescripcionProducto = "Producto 1",
                CategoriaProducto = "Categoria 1",
                Cantidad = 2,
                Precio = 100,
                Total = 100
            }
        };
    
        await _detalleVentaRepository.Save(detalleVentas);
    
        detalleVentas[0].CategoriaProducto = "Categoria 2";
        detalleVentas[1].CategoriaProducto = "Categoria 3";
    
        // Act
        await _detalleVentaRepository.Update(detalleVentas);
        var updatedDetalleVentas = await _context.DetalleVenta
            .Where(dv => detalleVentas.Select(det => det.Id).Contains(dv.Id))
            .ToListAsync();
    
        // Assert
        Assert.Equal(2, updatedDetalleVentas.Count);
        Assert.Contains(updatedDetalleVentas, dv => dv.CategoriaProducto == "Categoria 2");
        Assert.Contains(updatedDetalleVentas, dv => dv.CategoriaProducto == "Categoria 3");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}