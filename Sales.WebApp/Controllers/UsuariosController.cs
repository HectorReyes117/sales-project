using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Sales.WebApp.Extensions;
using Sales.WebApp.Models.Usuario;
using Sales.WebApp.Request;

namespace Sales.WebApp.Controllers;

public class UsuariosController : Controller
{
    private readonly IUsuariosRequests _userRequest; 
    private readonly IValidator<UsuarioCreationViewModel> _validator; 
    private readonly IValidator<UsuarioUpdateViewModel> _validatorUpdate; 

    public UsuariosController(
        IUsuariosRequests userRequest, 
        IValidator<UsuarioCreationViewModel> validator,
        IValidator<UsuarioUpdateViewModel> validatorUpdate
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
        UsuarioModel? user = null;
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
    public async Task<IActionResult> Create(UsuarioCreationViewModel usuarioCreationViewModel)
    {
        ValidationResult result = await _validator.ValidateAsync(usuarioCreationViewModel);
        
        if (!result.IsValid) 
        {

            result.AddToModelState(this.ModelState);
            return View("Create", usuarioCreationViewModel);
        }

        using HttpResponseMessage response = await _userRequest.Save(usuarioCreationViewModel);
        return RedirectToAction("Index", "Usuarios");
    }
    
    
    [Route("Usuarios/Edit/{id}")]
    public async Task<IActionResult> Edit([FromRoute]int id)
    {
        UsuarioModel? user = null;
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

        if (user!.Eliminado is true)
        {
            return RedirectToAction("Index");
        }
        
        return View(user.MapTo<UsuarioUpdateViewModel>());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Usuarios/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, UsuarioUpdateViewModel usuarioUpdateViewModel)
    {
        ValidationResult result = await _validatorUpdate.ValidateAsync(usuarioUpdateViewModel);
        
        if (!result.IsValid) 
        {

            result.AddToModelState(this.ModelState);
            return View("Edit", usuarioUpdateViewModel);
        }
        
        using HttpResponseMessage response = await _userRequest.Update(usuarioUpdateViewModel);
        return RedirectToAction("Index", "Usuarios");
    }
    
}