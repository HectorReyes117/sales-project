using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Interfaces;

namespace Sales.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IProductoRepository _productoRepository;
    private readonly  IVentaRepository _ventaRepository;

    public WeatherForecastController(IProductoRepository productoRepository, IVentaRepository ventaRepository)
    {
        _productoRepository = productoRepository;
        _ventaRepository = ventaRepository;
    }
    
    [HttpGet("products")]
    public async Task<IActionResult> GetProductsByCategory(string category)
    {
        return Ok(await _productoRepository.GetAllProductsByCategory(category));
    }
    
    [HttpGet("ventasByUser")]
    public async Task<IActionResult> GetSalesByUser(int userId)
    {
        return Ok(await _ventaRepository.GetSalesByUser(userId));
    }
}