using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.TipoDocumentoVentaDto;
using Sales.Application.Services;
using Sales.Infraestructure.Exceptions;

namespace Sales.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoDocumentoVentaController : ControllerBase
{
    private readonly ITipoDocumentoVentaService _tipoDocumentoVentaService;
    
    public TipoDocumentoVentaController(ITipoDocumentoVentaService tipoDocumentoVentaService)
    {
        _tipoDocumentoVentaService = tipoDocumentoVentaService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllTipoDocumentoVentas()
    {
        try
        {
            var tipoDocumentoVentas = await _tipoDocumentoVentaService.GetAll();
            return Ok(tipoDocumentoVentas);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> SaveTipoDocumentoVenta(TipoDocumentoVentaCreationDto tipoDocumentoVentaCreationDto)
    {
        try
        {
            await _tipoDocumentoVentaService.Save(tipoDocumentoVentaCreationDto);
            return Ok("Creado satisfactoriamente.");
        }
        catch (ArgumentNullException e )
        {
            return StatusCode(500, new { message = e.Message });
        }
        catch(TipoDocumentoVentaException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateTipoDocumentoVenta(TipoDocumentoVentaUpdateDto tipoDocumentoVentaUpdateDto)
    {
        try
        {
            await _tipoDocumentoVentaService.Update(tipoDocumentoVentaUpdateDto);
            return Ok("Actualizado satisfactoriamente.");
        }
        catch (ArgumentNullException e)
        {
            return StatusCode(500, new { message = e.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetTipoDocumentoVentaById(int id)
    {
        try
        {
            var tipoDocumentoVenta = await _tipoDocumentoVentaService.Get(id);
            return Ok(tipoDocumentoVenta);
        }
        catch (TipoDocumentoVentaException e)
        {
            return StatusCode(404, new { message = e.Message });
        }
    }
}