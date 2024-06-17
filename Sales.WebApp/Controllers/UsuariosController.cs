using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.UsuarioDto;
using Sales.Domain.Entities;
using Sales.WebApp.Extensions;
using Sales.WebApp.Request;

namespace Sales.WebApp.Controllers;

public class UsuariosController : Controller
{
    private readonly IUsuariosRequests _userRequest; 
    private readonly IValidator<UsuarioCreationDto> _validator; 
    private readonly IValidator<UsuarioUpdateDto> _validatorUpdate; 

    public UsuariosController(
        IUsuariosRequests userRequest, 
        IValidator<UsuarioCreationDto> validator,
        IValidator<UsuarioUpdateDto> validatorUpdate
        )
    {
        _userRequest = userRequest;
        _validator = validator;
        _validatorUpdate = validatorUpdate;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        return View(await _userRequest.GetAll());
    }
    
    [HttpPost("{id}")]
    public async Task<IActionResult> IndexDeleteUser(int id)
    {
        using HttpResponseMessage response = await _userRequest.DeleteUser(id);
        return RedirectToAction("Index", "Usuarios");
    }

    [Route("Usuarios/Detail/{id}")]
    public async Task<IActionResult> Detail([FromRoute] int id)
    {
        Usuario? user = null;
        try
        {
            user = await _userRequest.Get(id);
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                return RedirectToAction("Index"); 
            }
        }
        return View(user);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UsuarioCreationDto usuarioCreationDto)
    {
        ValidationResult result = await _validator.ValidateAsync(usuarioCreationDto);
        
        if (!result.IsValid) 
        {

            result.AddToModelState(this.ModelState);
            return View("Create", usuarioCreationDto);
        }

        using HttpResponseMessage response = await _userRequest.Save(usuarioCreationDto);
        return RedirectToAction("Index", "Usuarios");
    }
}