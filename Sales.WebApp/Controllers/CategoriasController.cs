using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Sales.WebApp.Extensions;
using Sales.WebApp.Models.Categories;
using Sales.WebApp.Request;

namespace Sales.WebApp.Controllers;

public class CategoriasController : Controller
{ 
     private readonly ICategoriaRequests _categoriaRequests;
    private readonly IValidator<CategoriaCreationViewModel> _validator;
    private readonly IValidator<CategoriaUpdateViewModel> _validatorUpdate;

    public CategoriasController(
        ICategoriaRequests categoriaRequests,
        IValidator<CategoriaCreationViewModel> validator,
        IValidator<CategoriaUpdateViewModel> validatorUpdate)
    {
        _categoriaRequests = categoriaRequests;
        _validator = validator;
        _validatorUpdate = validatorUpdate;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        return View(await _categoriaRequests.GetAll());
    }

    [HttpPost("Categorias/Index/{id}")]
    public async Task<IActionResult> IndexDeleteCategoria(int id)
    {
        using HttpResponseMessage response = await _categoriaRequests.DeleteCategory(id);
        return RedirectToAction("Index", "Categorias");
    }

    [Route("Categorias/Detail/{id}")]
    public async Task<IActionResult> Detail([FromRoute] int id)
    {
        CategoriaModel? category = null;
        try
        {
            category = await _categoriaRequests.Get(id);
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                return RedirectToAction("Index");
            }
        }
        return View(category);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoriaCreationViewModel categoriaCreationViewModel)
    {
        ValidationResult result = await _validator.ValidateAsync(categoriaCreationViewModel);

        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return View("Create", categoriaCreationViewModel);
        }

        using HttpResponseMessage response = await _categoriaRequests.Save(categoriaCreationViewModel);
        return RedirectToAction("Index", "Categorias");
    }

    [Route("Categorias/Edit/{id}")]
    public async Task<IActionResult> Edit([FromRoute]int id)
    {
        CategoriaModel? category = null;
        try
        {
            category = await _categoriaRequests.Get(id);
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                return RedirectToAction("Index");
            }
        }

        if (category!.Eliminado)
        {
            return RedirectToAction("Index");
        }

        var viewModel = category.MapTo<CategoriaUpdateViewModel>();

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Categorias/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, CategoriaUpdateViewModel categoriaUpdateViewModel)
    {
        ValidationResult result = await _validatorUpdate.ValidateAsync(categoriaUpdateViewModel);

        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return View("Edit", categoriaUpdateViewModel);
        }

        using HttpResponseMessage response = await _categoriaRequests.Update(categoriaUpdateViewModel);
        return RedirectToAction("Index", "Categorias");
    }
}