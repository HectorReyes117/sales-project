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

public class TipoDocumentoVentaRepositoryTest : IDisposable
{
    private readonly SalesContext _context;
    private readonly ITipoDocumentoVentaRepository _tipoDocumentoVentaRepository;
    private TipoDocumentoVenta _tipoDocumentoVenta;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TipoDocumentoVentaRepositoryTest()
    {
        IDbInMemory context = new DbInMemory();
        _context = context.CreateContext();
        _tipoDocumentoVentaRepository = new TipoDocumentoVentaRepository(_context, _httpContextAccessor);
        _tipoDocumentoVenta = new TipoDocumentoVenta()
        {
            Descripcion = "Factura",
            EsActivo = true
        };
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenTipoDocumentoVentaIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _tipoDocumentoVentaRepository.Save((TipoDocumentoVenta)null!));
    }

    [Fact]
    public async Task Save_ShouldSaveTipoDocumentoVenta_WhenTipoDocumentoVentaIsValid()
    {
        // Act
        await _tipoDocumentoVentaRepository.Save(_tipoDocumentoVenta);
        var savedTipoDocumentoVenta = await _context.TipoDocumentoVenta.FirstOrDefaultAsync(td => td.Descripcion == "Factura");

        // Assert
        Assert.NotNull(savedTipoDocumentoVenta);
        Assert.Equal("Factura", savedTipoDocumentoVenta.Descripcion);
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenTipoDocumentoVentaListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _tipoDocumentoVentaRepository.Save((List<TipoDocumentoVenta>)null!));
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenTipoDocumentoVentaListIsEmpty()
    {
        // Arrange
        var emptyList = new List<TipoDocumentoVenta>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<TipoDocumentoVentaException>(() => _tipoDocumentoVentaRepository.Save(emptyList));
        Assert.Equal("La cantidad de documentos debe ser mayor a cero.", exception.Message);
    }

    [Fact]
    public async Task Save_ShouldSaveTipoDocumentoVentas_WhenTipoDocumentoVentaListIsValid()
    {
        // Arrange
        var tipoDocumentoVentas = new List<TipoDocumentoVenta>
        {
            _tipoDocumentoVenta,
            new TipoDocumentoVenta()
            {
                Descripcion = "Boleta",
                EsActivo = true
            }
        };

        // Act
        await _tipoDocumentoVentaRepository.Save(tipoDocumentoVentas);
        var savedTipoDocumentoVentas = await _context.TipoDocumentoVenta.Where(td => td.EsActivo == true).ToListAsync();

        // Assert
        Assert.Equal(2, savedTipoDocumentoVentas.Count);
        Assert.Contains(savedTipoDocumentoVentas, td => td.Descripcion == "Factura");
        Assert.Contains(savedTipoDocumentoVentas, td => td.Descripcion == "Boleta");
    }

    [Fact]
    public async Task Get_ShouldThrowException_WhenTipoDocumentoVentaNotFound()
    {
        var exception = await Assert.ThrowsAsync<TipoDocumentoVentaException>(() => _tipoDocumentoVentaRepository.Get(999));
        Assert.Equal("Documento no encontrado.", exception.Message);
    }

    [Fact]
    public async Task Get_ShouldReturnTipoDocumentoVenta_WhenTipoDocumentoVentaExists()
    {
        // Arrange
        await _tipoDocumentoVentaRepository.Save(_tipoDocumentoVenta);

        // Act
        var result = await _tipoDocumentoVentaRepository.Get(_tipoDocumentoVenta.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(_tipoDocumentoVenta.Descripcion, result.Descripcion);
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenTipoDocumentoVentaIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _tipoDocumentoVentaRepository.Update((TipoDocumentoVenta)null!));
    }

    [Fact]
    public async Task Update_ShouldUpdateTipoDocumentoVenta_WhenTipoDocumentoVentaIsValid()
    {
        // Arrange
        await _tipoDocumentoVentaRepository.Save(_tipoDocumentoVenta);
        _tipoDocumentoVenta.Descripcion = "Nota de Crédito";

        // Act
        await _tipoDocumentoVentaRepository.Update(_tipoDocumentoVenta);
        var updatedTipoDocumentoVenta = await _tipoDocumentoVentaRepository.Get(_tipoDocumentoVenta.Id);

        // Assert
        Assert.NotNull(updatedTipoDocumentoVenta);
        Assert.Equal("Nota de Crédito", updatedTipoDocumentoVenta.Descripcion);
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenTipoDocumentoVentaListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _tipoDocumentoVentaRepository.Update((List<TipoDocumentoVenta>)null!));
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenTipoDocumentoVentaListIsEmpty()
    {
        // Arrange
        var emptyList = new List<TipoDocumentoVenta>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<TipoDocumentoVentaException>(() => _tipoDocumentoVentaRepository.Update(emptyList));
        Assert.Equal("La cantidad de documentos debe ser mayor a cero.", exception.Message);
    }

    [Fact]
    public async Task Update_ShouldUpdateTipoDocumentoVentas_WhenTipoDocumentoVentaListIsValid()
    {
        // Arrange
        var tipoDocumentoVentas = new List<TipoDocumentoVenta>
        {
            _tipoDocumentoVenta,
            new TipoDocumentoVenta()
            {
                Descripcion = "Boleta",
                EsActivo = true
            }
        };

        await _tipoDocumentoVentaRepository.Save(tipoDocumentoVentas);

        tipoDocumentoVentas[0].Descripcion = "Factura Actualizada";
        tipoDocumentoVentas[1].Descripcion = "Boleta Actualizada";

        // Act
        await _tipoDocumentoVentaRepository.Update(tipoDocumentoVentas);
        var updatedTipoDocumentoVentas = await _context.TipoDocumentoVenta.Where(td => tipoDocumentoVentas.Select(tdv => tdv.Id).Contains(td.Id)).ToListAsync();

        // Assert
        Assert.Equal(2, updatedTipoDocumentoVentas.Count);
        Assert.Contains(updatedTipoDocumentoVentas, td => td.Descripcion == "Factura Actualizada");
        Assert.Contains(updatedTipoDocumentoVentas, td => td.Descripcion == "Boleta Actualizada");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}