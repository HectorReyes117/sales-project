using AutoMapper;
using Sales.Application.Dtos.VentaDto;
using Sales.Domain.Entities;

namespace Sales.Application.Mappers;

public class VentaProfile : Profile
{
    public VentaProfile()
    {
        CreateMap<VentaCreationDto, Venta>();
        CreateMap<Venta, VentaCreationDto>();
        CreateMap<VentaUpdateDto, Venta>();
        CreateMap<Venta, VentaUpdateDto>();
    }
}