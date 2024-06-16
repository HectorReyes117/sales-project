using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.ProductoDto;
using Sales.Application.Services;
using Sales.Infraestructure.Exceptions;

namespace Sales.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;
    
    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllProductos()
    {
        try
        {
            var productos = await _productoService.GetAll();
            return Ok(productos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> SaveProducto(ProductoCreationDto productoCreationDto)
    {
        try
        {
            await _productoService.Save(productoCreationDto);
            return Ok("Creado satisfactoriamente.");
        }
        catch (ArgumentNullException e )
        {
            return StatusCode(500, new { message = e.Message });
        }
        catch(ProductException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProducto(ProductoUpdateDto productoUpdateDto)
    {
        try
        {
            await _productoService.Update(productoUpdateDto);
            return Ok("Actualizado satisfactoriamente.");
        }
        catch (ArgumentNullException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetProductoById(int id)
    {
        try
        {
            var producto = await _productoService.Get(id);
            return Ok(producto);
        }
        catch (ProductException e)
        {
            return StatusCode(404, new { message = e.Message });
        }
    }
}