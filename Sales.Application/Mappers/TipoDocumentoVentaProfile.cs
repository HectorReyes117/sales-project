using AutoMapper;
using Sales.Application.Dtos.TipoDocumentoVentaDto;
using Sales.Domain.Entities;

namespace Sales.Application.Mappers;

public class TipoDocumentoVentaProfile : Profile
{
    public TipoDocumentoVentaProfile()
    {
        CreateMap<TipoDocumentoVentaCreationDto, TipoDocumentoVenta>();
        CreateMap<Venta, TipoDocumentoVentaCreationDto>();
        CreateMap<TipoDocumentoVentaUpdateDto, TipoDocumentoVenta>();
        CreateMap<TipoDocumentoVenta, TipoDocumentoVentaUpdateDto>();
    }
}