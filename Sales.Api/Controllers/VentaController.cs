using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.VentaDto;
using Sales.Application.Services;
using Sales.Infraestructure.Exceptions;

namespace Sales.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VentaController : ControllerBase
{
    private readonly IVentaService _ventaService;
    
    public VentaController(IVentaService ventaService)
    {
        _ventaService = ventaService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllVentas()
    {
        try
        {
            var ventas = await _ventaService.GetAll();
            return Ok(ventas);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> SaveVenta(VentaCreationDto ventaCreationDto)
    {
        try
        {
            await _ventaService.Save(ventaCreationDto);
            return Ok("Creado satisfactoriamente.");
        }
        catch (ArgumentNullException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
        catch(VentaException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateVenta(VentaUpdateDto ventaUpdateDto)
    {
        try
        {
            await _ventaService.Update(ventaUpdateDto);
            return Ok("Actualizado satisfactoriamente.");
        }
        catch (ArgumentNullException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetVentaById(int id)
    {
        try
        {
            var venta = await _ventaService.Get(id);
            return Ok(venta);
        }
        catch (VentaException e)
        {
            return StatusCode(404, new { message = e.Message });
        }
    }
}