using AutoMapper;
using FluentValidation;
using Sales.Application.Dtos.TipoDocumentoVentaDto;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services.Implementations;

public class TipoDocumentoVentaService : ITipoDocumentoVentaService
{
    private readonly ITipoDocumentoVentaRepository _tipoDocumentoVentaRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<TipoDocumentoVentaCreationDto> _validator;
    private readonly IValidator<TipoDocumentoVentaUpdateDto> _validatorUpdate;
    
    public TipoDocumentoVentaService(
        ITipoDocumentoVentaRepository tipoDocumentoVentaRepository, 
        IMapper mapper, 
        IValidator<TipoDocumentoVentaCreationDto> validator, 
        IValidator<TipoDocumentoVentaUpdateDto> validatorUpdate
        )
    {
        _tipoDocumentoVentaRepository = tipoDocumentoVentaRepository;
        _mapper = mapper;
        _validator = validator;
        _validatorUpdate = validatorUpdate;
    }
    
    public async Task Save(TipoDocumentoVentaCreationDto tipoDocumentoVentaCreation)
    {
        await _validator.ValidateAndThrowAsync(tipoDocumentoVentaCreation);
        TipoDocumentoVenta typeDocument = _mapper.Map<TipoDocumentoVenta>(tipoDocumentoVentaCreation);
        await _tipoDocumentoVentaRepository.Save(typeDocument);
    }

    public async Task Update(TipoDocumentoVentaUpdateDto tipoDocumentoVentaCreation)
    {
        await _validatorUpdate.ValidateAndThrowAsync(tipoDocumentoVentaCreation);
        TipoDocumentoVenta typeDocument = _mapper.Map<TipoDocumentoVenta>(tipoDocumentoVentaCreation);
        await _tipoDocumentoVentaRepository.Update(typeDocument);
    }

    public async Task<TipoDocumentoVenta?> Get(int id)
    {
        return await _tipoDocumentoVentaRepository.Get(id);
    }

    public async Task<List<TipoDocumentoVenta>> GetAll()
    {
        return await _tipoDocumentoVentaRepository.GetAll(null!);
    }
}