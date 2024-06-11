using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Repositories;

namespace Sales.Infraestructure.test.Repositories;

public class CategoriaRepositoryTest
{
    private readonly SalesContext _context;
    private readonly ICategoriaRepository _categoriaRepository;
    
    public CategoriaRepositoryTest()
    {
        var options = new DbContextOptionsBuilder<SalesContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new SalesContext(options);
        _context.Database.EnsureCreated();
        _categoriaRepository = new CategoriaRepository(_context);
    }    
    
    [Fact]
    public async void Save_ShouldThrowException_WhenCategoriaIsNotUnique()
    {
        // Arrange
        var categoria = new Categoria { Descripcion = "UniqueCategoria" };

        await _categoriaRepository.Save(categoria);

        // Act & Assert
        var newCategoria = new Categoria { Descripcion = "UniqueCategoria" };
        var exception = await Assert.ThrowsAsync<CategoriaException>(() => _categoriaRepository.Save(newCategoria));
        Assert.Equal("La categoria debe ser ùnica.", exception.Message);
    }
    
    [Fact]
    public async Task Save_ShouldSaveCategoria_WhenCategoriaIsUnique()
    {
        // Arrange
        var categoria = new Categoria { Descripcion = "NewCategoria" };

        // Act
        await _categoriaRepository.Save(categoria);
        var savedCategoria = await _context.Categoria.FirstOrDefaultAsync(c => c.Descripcion == "NewCategoria");

        // Assert
        Assert.NotNull(savedCategoria);
        Assert.Equal("NewCategoria", savedCategoria.Descripcion);
    }
    
    [Fact]
    public async Task Save_ShouldThrowException_WhenCategoriasListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _categoriaRepository.Save((List<Categoria>)null));
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenCategoriasListIsEmpty()
    {
        // Arrange
        var emptyList = new List<Categoria>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<CategoriaException>(() => _categoriaRepository.Save(emptyList));
        Assert.Equal("La cantidad de categorias debe ser mayor a cero.", exception.Message);
    }
    
    [Fact]
    public async Task Save_ShouldSaveCategorias_WhenCategoriasListIsValid()
    {
        // Arrange
        var categorias = new List<Categoria>
        {
            new Categoria { Descripcion = "Categoria1" },
            new Categoria { Descripcion = "Categoria2" }
        };

        // Act
        await _categoriaRepository.Save(categorias);
        var savedCategorias = await _context.Categoria.Where(c => categorias.Select(cat => cat.Descripcion).Contains(c.Descripcion)).ToListAsync();

        // Assert
        Assert.Equal(2, savedCategorias.Count);
        Assert.Contains(savedCategorias, c => c.Descripcion == "Categoria1");
        Assert.Contains(savedCategorias, c => c.Descripcion == "Categoria2");
    }
    
    [Fact]
    public async Task Get_ShouldThrowException_WhenCategoriaNotFound()
    {
        var exception = await Assert.ThrowsAsync<CategoriaException>(() => _categoriaRepository.Get(999));
        Assert.Equal("Categoria no encontrada", exception.Message);
    }
    
    [Fact]
    public async Task Get_ShouldReturnCategoria_WhenCategoriaExists()
    {
        // Arrange
        var categoria = new Categoria { Descripcion = "ExistingCategoria" };
        await _categoriaRepository.Save(categoria);

        // Act
        var result = await _categoriaRepository.Get(categoria.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(categoria.Descripcion, result.Descripcion);
    }
    
    [Fact]
    public async Task Update_ShouldThrowException_WhenCategoriaIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _categoriaRepository.Update((Categoria)null));
    }
    
    [Fact]
    public async Task Update_ShouldUpdateCategoria_WhenCategoriaIsValid()
    {
        // Arrange
        var categoria = new Categoria { Descripcion = "ExistingCategoria" };

        await _categoriaRepository.Save(categoria);
        categoria.Descripcion = "UpdatedCategoria";

        // Act
        await _categoriaRepository.Update(categoria);
        var updatedCategoria = await _categoriaRepository.Get(categoria.Id);

        // Assert
        Assert.NotNull(updatedCategoria);
        Assert.Equal("UpdatedCategoria", updatedCategoria.Descripcion);
    }
    
    [Fact]
    public async Task Update_ShouldThrowException_WhenCategoriasListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _categoriaRepository.Update((List<Categoria>)null));
    }
    
    [Fact]
    public async Task Update_ShouldThrowException_WhenCategoriasListIsEmpty()
    {
        // Arrange
        var emptyList = new List<Categoria>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<CategoriaException>(() => _categoriaRepository.Update(emptyList));
        Assert.Equal("La cantidad de categorias debe ser mayor a cero.", exception.Message);
    }
    
    [Fact]
    public async Task Update_ShouldUpdateCategorias_WhenCategoriasListIsValid()
    {
        // Arrange
        var categories = new List<Categoria>
        {
            new Categoria { Descripcion = "Categoria1" },
            new Categoria { Descripcion = "Categoria2" }
        };

        await _categoriaRepository.Save(categories);

        categories[0].Descripcion = "UpdatedCategoria1";
        categories[1].Descripcion = "UpdatedCategoria2";

        // Act
        await _categoriaRepository.Update(categories);
        var updatedCategorias = await _context.Categoria.Where(c => categories.Select(cat => cat.Id).Contains(c.Id)).ToListAsync();

        // Assert
        Assert.Equal(2, updatedCategorias.Count);
        Assert.Contains(updatedCategorias, c => c.Descripcion == "UpdatedCategoria1");
        Assert.Contains(updatedCategorias, c => c.Descripcion == "UpdatedCategoria2");
    }


}