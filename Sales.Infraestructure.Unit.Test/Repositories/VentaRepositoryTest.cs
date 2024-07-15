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

public class VentaRepositoryTest : IDisposable
{
    private readonly SalesContext _context;
    private readonly IVentaRepository _ventaRepository;
    private Venta _venta;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public VentaRepositoryTest()
    {
        IDbInMemory context = new DbInMemory();
        _context = context.CreateContext();
        _ventaRepository = new VentaRepository(_context, _httpContextAccessor);
        _venta = new Venta()
        {
            NumeroVenta = "V001",
            IdTipoDocumentoVenta = 1,
            IdUsuario = 1,
            CocumentoCliente = "12345678",
            NombreCliente = "Cliente Ejemplo",
            SubTotal = 100.00M,
            ImpuestoTotal = 18.00M,
            Total = 118.00M
        };
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenVentaIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _ventaRepository.Save((Venta)null!));
    }

    [Fact]
    public async Task Save_ShouldSaveVenta_WhenVentaIsValid()
    {
        // Act
        await _ventaRepository.Save(_venta);
        var savedVenta = await _context.Venta.FirstOrDefaultAsync(v => v.NumeroVenta == "V001");

        // Assert
        Assert.NotNull(savedVenta);
        Assert.Equal("V001", savedVenta.NumeroVenta);
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenVentaListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _ventaRepository.Save((List<Venta>)null!));
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenVentaListIsEmpty()
    {
        // Arrange
        var emptyList = new List<Venta>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<VentaException>(() => _ventaRepository.Save(emptyList));
        Assert.Equal("La cantidad de ventas debe ser mayor a cero.", exception.Message);
    }

    [Fact]
    public async Task Save_ShouldSaveVentas_WhenVentaListIsValid()
    {
        // Arrange
        var ventas = new List<Venta>
        {
            _venta,
            new Venta()
            {
                NumeroVenta = "V002",
                IdTipoDocumentoVenta = 1,
                IdUsuario = 2,
                CocumentoCliente = "87654321",
                NombreCliente = "Otro Cliente",
                SubTotal = 200.00M,
                ImpuestoTotal = 36.00M,
                Total = 236.00M
            }
        };

        // Act
        await _ventaRepository.Save(ventas);
        var savedVentas = await _context.Venta.ToListAsync();

        // Assert
        Assert.Equal(2, savedVentas.Count);
        Assert.Contains(savedVentas, v => v.NumeroVenta == "V001");
        Assert.Contains(savedVentas, v => v.NumeroVenta == "V002");
    }

    [Fact]
    public async Task Get_ShouldThrowException_WhenVentaNotFound()
    {
        var exception = await Assert.ThrowsAsync<VentaException>(() => _ventaRepository.Get(999));
        Assert.Equal("Venta no encontrada", exception.Message);
    }

    [Fact]
    public async Task Get_ShouldReturnVenta_WhenVentaExists()
    {
        // Arrange
        await _ventaRepository.Save(_venta);

        // Act
        var result = await _ventaRepository.Get(_venta.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(_venta.NumeroVenta, result.NumeroVenta);
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenVentaIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _ventaRepository.Update((Venta)null!));
    }

    [Fact]
    public async Task Update_ShouldUpdateVenta_WhenVentaIsValid()
    {
        // Arrange
        await _ventaRepository.Save(_venta);
        _venta.NumeroVenta = "V001-Actualizada";

        // Act
        await _ventaRepository.Update(_venta);
        var updatedVenta = await _ventaRepository.Get(_venta.Id);

        // Assert
        Assert.NotNull(updatedVenta);
        Assert.Equal("V001-Actualizada", updatedVenta.NumeroVenta);
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenVentaListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _ventaRepository.Update((List<Venta>)null!));
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenVentaListIsEmpty()
    {
        // Arrange
        var emptyList = new List<Venta>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<VentaException>(() => _ventaRepository.Update(emptyList));
        Assert.Equal("La cantidad de ventas debe ser mayor a cero.", exception.Message);
    }

    [Fact]
    public async Task Update_ShouldUpdateVentas_WhenVentaListIsValid()
    {
        // Arrange
        var ventas = new List<Venta>
        {
            _venta,
            new Venta()
            {
                NumeroVenta = "V002",
                IdTipoDocumentoVenta = 1,
                IdUsuario = 2,
                CocumentoCliente = "87654321",
                NombreCliente = "Otro Cliente",
                SubTotal = 200.00M,
                ImpuestoTotal = 36.00M,
                Total = 236.00M
            }
        };

        await _ventaRepository.Save(ventas);

        ventas[0].NumeroVenta = "V001-Actualizada";
        ventas[1].NumeroVenta = "V002-Actualizada";

        // Act
        await _ventaRepository.Update(ventas);
        var updatedVentas = await _context.Venta.Where(v => ventas.Select(ve => ve.Id).Contains(v.Id)).ToListAsync();

        // Assert
        Assert.Equal(2, updatedVentas.Count);
        Assert.Contains(updatedVentas, v => v.NumeroVenta == "V001-Actualizada");
        Assert.Contains(updatedVentas, v => v.NumeroVenta == "V002-Actualizada");
    }

    [Fact]
    public async Task GetSalesByUser_ShouldThrowException_WhenUserNotFound()
    {
        var exception = await Assert.ThrowsAsync<VentaException>(() => _ventaRepository.GetSalesByUser(999));
        Assert.Equal("El usuario no existe.", exception.Message);
    }

    [Fact]
    public async Task GetSalesByUser_ShouldReturnVentas_WhenUserExists()
    {
        // Arrange
        var usuario = new Usuario
        {
            Id = 1,
            Nombre = "Usuario Ejemplo"
        };
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        await _ventaRepository.Save(_venta);

        // Act
        var result = await _ventaRepository.GetSalesByUser(usuario.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Usuario Ejemplo", result.Vendedor);
        Assert.Equal(1, result.NumeroVenta);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}