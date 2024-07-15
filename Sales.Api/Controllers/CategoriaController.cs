using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.CategoriesDto;
using Sales.Application.Services;
using Sales.Infraestructure.Exceptions;

namespace Sales.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;
    
    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllCategories()
    {
        try
        {
            var categories = await _categoriaService.GeAllWithFilter();
            return Ok(categories);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> SaveCategory(CategoriaCreationDto categoriaCreationDto)
    {
        try
        {
            await _categoriaService.Save(categoriaCreationDto);
            return Ok("Creado satisfactoriamente.");
        }
        catch (ArgumentNullException e )
        {
            return StatusCode(500, new { message = e.Message });
        }
        catch(CategoriaException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCategory(CategoriaUpdateDto categoriaUpdateDto)
    {
        try
        {
            await _categoriaService.Update(categoriaUpdateDto);
            return Ok("Actualizado satisfactoriamente.");
        }
        catch (ArgumentNullException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCategoryById(int id)
    {
        try
        {
            return Ok(await _categoriaService.Get(id));
        }
        catch (CategoriaException e)
        {
            return StatusCode(404, new { message = e.Message });
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategoryById(int id)
    {
        try
        {
            await _categoriaService.DeleteCategory(id);
            return Ok("Eliminado Satisfactoriamente");
        }
        catch (CategoriaException e)
        {
            return StatusCode(404, new { message = e.Message });
        }
    }
}