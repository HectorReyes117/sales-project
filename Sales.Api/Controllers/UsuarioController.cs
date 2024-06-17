using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.UsuarioDto;
using Sales.Application.Services;
using Sales.Infraestructure.Exceptions;

namespace Sales.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllUsuarios()
    {
        try
        {
            var usuarios = await _usuarioService.GetAll();
            return Ok(usuarios);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> SaveUsuario(UsuarioCreationDto usuarioCreationDto)
    {
        try
        {
            await _usuarioService.Save(usuarioCreationDto);
            return Ok("Creado satisfactoriamente.");
        }
        catch (ArgumentNullException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
        catch(UsuarioException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUsuario(UsuarioUpdateDto usuarioUpdateDto)
    {
        try
        {
            await _usuarioService.Update(usuarioUpdateDto);
            return Ok("Actualizado satisfactoriamente.");
        }
        catch (ArgumentNullException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUsuarioById(int id)
    {
        try
        {
            var usuario = await _usuarioService.Get(id);
            return Ok(usuario);
        }
        catch (UsuarioException e)
        {
            return StatusCode(404, new { message = e.Message });
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUserById(int id)
    {
        try
        {
            await _usuarioService.DeleteUser(id);
            return Ok("Eliminado Satisfactoriamente");
        }
        catch (UsuarioException e)
        {
            return StatusCode(404, new { message = e.Message });
        }
    }
}