using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Mappers;
using Sales.Infraestructure.Repositories;
using Sales.Infraestructure.test.AbstractionsTests;
using Sales.Infraestructure.test.AbstractionsTests.Implementations;

namespace Sales.Infraestructure.test.Repositories;

public class UsuarioRepositoryTest : IDisposable
{
    private readonly SalesContext _context;
    private readonly IUsuarioRepository _usuarioRepository;
    private Usuario _usuario;

    public UsuarioRepositoryTest()
    {
        IDbInMemory context = new DbInMemory();
        _context = context.CreateContext();
        _usuarioRepository = new UsuarioRepository(_context);
        _usuario = new Usuario()
        {
            Nombre = "Juan Perez",
            Correo = "juan.perez@example.com",
            Telefono = "123456789",
            IdRol = 1,
            UrlFoto = "http://example.com/foto.jpg",
            NombreFoto = "foto.jpg",
            Clave = "securepassword",
            EsActivo = true
        };
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenUsuarioIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _usuarioRepository.Save((Usuario)null!));
    }

    [Fact]
    public async Task Save_ShouldSaveUsuario_WhenUsuarioIsValid()
    {
        // Act
        await _usuarioRepository.Save(_usuario);
        var savedUsuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nombre == "Juan Perez");

        // Assert
        Assert.NotNull(savedUsuario);
        Assert.Equal("Juan Perez", savedUsuario.Nombre);
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenUsuarioListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _usuarioRepository.Save((List<Usuario>)null!));
    }

    [Fact]
    public async Task Save_ShouldThrowException_WhenUsuarioListIsEmpty()
    {
        // Arrange
        var emptyList = new List<Usuario>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<UsuarioException>(() => _usuarioRepository.Save(emptyList));
        Assert.Equal("La cantidad de usuarios debe ser mayor a cero.", exception.Message);
    }

    [Fact]
    public async Task Save_ShouldSaveUsuarios_WhenUsuarioListIsValid()
    {
        // Arrange
        var usuarios = new List<Usuario>
        {
            _usuario,
            new Usuario()
            {
                Nombre = "Ana Gomez",
                Correo = "ana.gomez@example.com",
                Telefono = "987654321",
                IdRol = 2,
                UrlFoto = "http://example.com/foto2.jpg",
                NombreFoto = "foto2.jpg",
                Clave = "securepassword2",
                EsActivo = true
            }
        };

        // Act
        await _usuarioRepository.Save(usuarios);
        var savedUsuarios = await _context.Usuarios.Where(u => u.EsActivo == true).ToListAsync();

        // Assert
        Assert.Equal(2, savedUsuarios.Count);
        Assert.Contains(savedUsuarios, u => u.Nombre == "Juan Perez");
        Assert.Contains(savedUsuarios, u => u.Nombre == "Ana Gomez");
    }

    [Fact]
    public async Task GetByUserId_ShouldThrowException_WhenUsuarioNotFound()
    {
        var exception = await Assert.ThrowsAsync<UsuarioException>(() => _usuarioRepository.GetByUserId(999));
        Assert.Equal("Usuario no encontrada", exception.Message);
    }

    [Fact]
    public async Task GetByUserId_ShouldReturnUsuario_WhenUsuarioExists()
    {
        // Arrange
        await _usuarioRepository.Save(_usuario);

        // Act
        var result = await _usuarioRepository.GetByUserId(_usuario.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(_usuario.Nombre, result.Nombre);
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenUsuarioIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _usuarioRepository.Update((Usuario)null!));
    }

    [Fact]
    public async Task Update_ShouldUpdateUsuario_WhenUsuarioIsValid()
    {
        // Arrange
        await _usuarioRepository.Save(_usuario);
        _usuario.Nombre = "Juan Perez Actualizado";

        // Act
        await _usuarioRepository.Update(_usuario);
        var updatedUsuario = await _usuarioRepository.Get(_usuario.Id);

        // Assert
        Assert.NotNull(updatedUsuario);
        Assert.Equal("Juan Perez Actualizado", updatedUsuario.Nombre);
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenUsuarioListIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _usuarioRepository.Update((List<Usuario>)null!));
    }

    [Fact]
    public async Task Update_ShouldThrowException_WhenUsuarioListIsEmpty()
    {
        // Arrange
        var emptyList = new List<Usuario>();

        // Act & Assert
        var exception = await Assert.ThrowsAsync<UsuarioException>(() => _usuarioRepository.Update(emptyList));
        Assert.Equal("La cantidad de usuarios debe ser mayor a cero.", exception.Message);
    }

    [Fact]
    public async Task Update_ShouldUpdateUsuarios_WhenUsuarioListIsValid()
    {
        // Arrange
        var usuarios = new List<Usuario>
        {
            _usuario,
            new Usuario()
            {
                Nombre = "Ana Gomez",
                Correo = "ana.gomez@example.com",
                Telefono = "987654321",
                IdRol = 2,
                UrlFoto = "http://example.com/foto2.jpg",
                NombreFoto = "foto2.jpg",
                Clave = "securepassword2",
                EsActivo = true
            }
        };

        await _usuarioRepository.Save(usuarios);

        usuarios[0].Nombre = "Juan Perez Actualizado";
        usuarios[1].Nombre = "Ana Gomez Actualizada";

        // Act
        await _usuarioRepository.Update(usuarios);
        var updatedUsuarios = await _context.Usuarios.Where(u => usuarios.Select(us => us.Id).Contains(u.Id)).ToListAsync();

        // Assert
        Assert.Equal(2, updatedUsuarios.Count);
        Assert.Contains(updatedUsuarios, u => u.Nombre == "Juan Perez Actualizado");
        Assert.Contains(updatedUsuarios, u => u.Nombre == "Ana Gomez Actualizada");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}