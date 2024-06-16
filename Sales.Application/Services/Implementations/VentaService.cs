using AutoMapper;
using FluentValidation;
using Sales.Application.Dtos.VentaDto;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services.Implementations;

public class VentaService : IVentaService
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<VentaCreationDto> _validator;
    private readonly IValidator<VentaUpdateDto> _validatorUpdate;
    
    public VentaService(
        IMapper mapper, 
        IValidator<VentaCreationDto> validator, 
        IValidator<VentaUpdateDto> validatorUpdate,
        IVentaRepository ventaRepository
        )
    {
        _mapper = mapper;
        _validator = validator;
        _validatorUpdate = validatorUpdate;
        _ventaRepository = ventaRepository;
    }
    
    public async Task Save(VentaCreationDto venta)
    {
        await _validator.ValidateAndThrowAsync(venta);
        Venta vent = _mapper.Map<Venta>(venta);
        await _ventaRepository.Save(vent);    
    }

    public async Task Update(VentaUpdateDto venta)
    {
        await _validatorUpdate.ValidateAndThrowAsync(venta);
        Venta vent = _mapper.Map<Venta>(venta);
        await _ventaRepository.Update(vent);
    }

    public async Task<Venta?> Get(int id)
    {
        return await _ventaRepository.Get(id);
    }

    public async Task<List<Venta>> GetAll()
    {
        return await _ventaRepository.GetAll(null!);
    }
}