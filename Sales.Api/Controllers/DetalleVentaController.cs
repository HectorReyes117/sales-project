using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.DetalleVentaDto;
using Sales.Application.Services;
using Sales.Infraestructure.Exceptions;

namespace Sales.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DetalleVentaController : ControllerBase
{
    private readonly IDetalleVentaService _detalleVentaService;
    
    public DetalleVentaController(IDetalleVentaService detalleVentaService)
    {
        _detalleVentaService = detalleVentaService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllDetalleVentas()
    {
        try
        {
            var detalleVentas = await _detalleVentaService.GetAll();
            return Ok(detalleVentas);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> SaveDetalleVenta(DetalleVentaCreationDto detalleVentaCreationDto)
    {
        try
        {
            await _detalleVentaService.Save(detalleVentaCreationDto);
            return Ok("Creado satisfactoriamente.");
        }
        catch (ArgumentNullException e )
        {
            return StatusCode(500, new { message = e.Message });
        }
        catch(DetalleVentaException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateDetalleVenta(DetalleVentaUpdateDto detalleVentaUpdateDto)
    {
        try
        {
            await _detalleVentaService.Update(detalleVentaUpdateDto);
            return Ok("Actualizado satisfactoriamente.");
        }
        catch (ArgumentNullException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetDetalleVentaById(int id)
    {
        try
        {
            return Ok(await _detalleVentaService.Get(id));
        }
        catch (DetalleVentaException e)
        {
            return StatusCode(404, new { message = e.Message });
        }
    }
}