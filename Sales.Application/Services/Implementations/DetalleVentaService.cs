using AutoMapper;
using FluentValidation;
using Sales.Application.Dtos.DetalleVentaDto;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services.Implementations;

public class DetalleVentaService : IDetalleVentaService
{
    private readonly IDetalleVentaRepository _detalleVentaRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<DetalleVentaCreationDto> _validator;
    private readonly IValidator<DetalleVentaUpdateDto> _validatorUpdate;
    
    public DetalleVentaService(
        IDetalleVentaRepository detalleVentaRepository, 
        IMapper mapper, 
        IValidator<DetalleVentaCreationDto> validator, 
        IValidator<DetalleVentaUpdateDto> validatorUpdate
        )
    {
        _detalleVentaRepository = detalleVentaRepository;
        _mapper = mapper;
        _validator = validator;
        _validatorUpdate = validatorUpdate;
    }
    
    public async Task Save(DetalleVentaCreationDto detalleVenta)
    {
        await _validator.ValidateAndThrowAsync(detalleVenta);
        DetalleVenta sailDetail = _mapper.Map<DetalleVenta>(detalleVenta);
        await _detalleVentaRepository.Save(sailDetail);    
    }

    public async Task Update(DetalleVentaUpdateDto detalleVenta)
    {
        await _validatorUpdate.ValidateAndThrowAsync(detalleVenta);
        DetalleVenta sailDetail = _mapper.Map<DetalleVenta>(detalleVenta);
        await _detalleVentaRepository.Update(sailDetail);
    }

    public async Task<DetalleVenta?> Get(int id)
    {
        return await _detalleVentaRepository.Get(id);
    }

    public async Task<List<DetalleVenta>> GetAll()
    {
        return await _detalleVentaRepository.GetAll(null!);
    }
}