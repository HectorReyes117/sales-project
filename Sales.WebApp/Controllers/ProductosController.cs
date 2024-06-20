using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sales.WebApp.Extensions;
using Sales.WebApp.Models.Categories;
using Sales.WebApp.Models.Producto;
using Sales.WebApp.Request;

namespace Sales.WebApp.Controllers;

public class ProductosController : Controller
{
    private readonly IProductoRequests _productRequest;
    private readonly ICategoriaRequests _categoriaRequests;
    private readonly IValidator<ProductoCreationViewModel> _validator;
    private readonly IValidator<ProductoUpdateViewModel> _validatorUpdate;

    public ProductosController(
        IProductoRequests productRequest,
        IValidator<ProductoCreationViewModel> validator,
        IValidator<ProductoUpdateViewModel> validatorUpdate, 
        ICategoriaRequests categoriaRequests)
    {
        _productRequest = productRequest;
        _validator = validator;
        _validatorUpdate = validatorUpdate;
        _categoriaRequests = categoriaRequests;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        return View(await _productRequest.GetAll());
    }

    [HttpPost("Productos/Index/{id}")]
    public async Task<IActionResult> IndexDeleteProduct(int id)
    {
        using HttpResponseMessage response = await _productRequest.DeleteProduct(id);
        return RedirectToAction("Index", "Productos");
    }

    [Route("Productos/Detail/{id}")]
    public async Task<IActionResult> Detail([FromRoute] int id)
    {
        ProductoModel? product = null;
        try
        {
            product = await _productRequest.Get(id);
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                return RedirectToAction("Index");
            }
        }
        return View(product);
    }

    public async Task<IActionResult> Create()
    {
        var categories = await _categoriaRequests.GetAll();
        ProductoCreationViewModel product = new ProductoCreationViewModel();
        product.Categories = categories;
        TempData["Categories"] = JsonConvert.SerializeObject(categories);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductoCreationViewModel productoCreationViewModel)
    {
        ValidationResult result = await _validator.ValidateAsync(productoCreationViewModel);

        if (!result.IsValid)
        {
            if (TempData["Categories"] != null)
            {
                productoCreationViewModel.Categories = JsonConvert.DeserializeObject<List<CategoriaModel>>(TempData["Categories"]?.ToString());
            }

            else
            {
                productoCreationViewModel.Categories = await _categoriaRequests.GetAll();
            }
            
            result.AddToModelState(this.ModelState);
            return View("Create", productoCreationViewModel);
        }

        using HttpResponseMessage response = await _productRequest.Save(productoCreationViewModel);
        return RedirectToAction("Index", "Productos");
    }

    [Route("Productos/Edit/{id}")]
    public async Task<IActionResult> Edit([FromRoute]int id)
    {
        ProductoModel? product = null;
        try
        {
            product = await _productRequest.Get(id);
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                return RedirectToAction("Index");
            }
        }

        if (product!.Eliminado)
        {
            return RedirectToAction("Index");
        }

        var viewModel = product.MapTo<ProductoUpdateViewModel>();
        var categories = await _categoriaRequests.GetAll();
        viewModel.Categories = categories;
        TempData["Categories"] = JsonConvert.SerializeObject(categories);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Productos/Edit/{id}")]
    public async Task<IActionResult> Edit(int id, ProductoUpdateViewModel productoUpdateViewModel)
    {
        ValidationResult result = await _validatorUpdate.ValidateAsync(productoUpdateViewModel);

        if (!result.IsValid)
        {
            if (TempData["Categories"] != null)
            {
                productoUpdateViewModel.Categories = JsonConvert.DeserializeObject<List<CategoriaModel>>(TempData["Categories"]?.ToString());
            }
            else
            {
                productoUpdateViewModel.Categories = await _categoriaRequests.GetAll();
            }
            
            result.AddToModelState(this.ModelState);
            return View("Edit", productoUpdateViewModel);
        }

        using HttpResponseMessage response = await _productRequest.Update(productoUpdateViewModel);
        return RedirectToAction("Index", "Productos");
    }

}