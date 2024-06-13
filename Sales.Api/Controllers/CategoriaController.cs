using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.CategoriesDto;
using Sales.Application.Services;

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

    [HttpPost]
    public async Task<ActionResult> SaveCategory(CategoriaCreationDto categoriaCreationDto)
    {
        await this._categoriaService.Save(categoriaCreationDto);
        return Ok("Creado satisfactoriamente.");
    }
}