using AutoMapper;
using Sales.Application.Dtos.DetalleVentaDto;
using Sales.Domain.Entities;

namespace Sales.Application.Mappers;

public class DetalleVentaProfile : Profile
{
    public DetalleVentaProfile()
    {
        CreateMap<DetalleVentaCreationDto, DetalleVenta>();
        CreateMap<DetalleVenta, DetalleVentaUpdateDto>();
        CreateMap<DetalleVentaUpdateDto, DetalleVenta>();
        CreateMap<DetalleVenta, DetalleVentaUpdateDto>();
    }
}