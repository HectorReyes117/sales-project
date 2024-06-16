using AutoMapper;
using Sales.Application.Dtos.ProductoDto;
using Sales.Domain.Entities;

namespace Sales.Application.Mappers;

public class ProductoProfile : Profile
{
    public ProductoProfile()
    {
        CreateMap<ProductoCreationDto, Producto>();
        CreateMap<ProductoCreationDto, ProductoCreationDto>();
        CreateMap<ProductoUpdateDto, Producto>();
        CreateMap<Producto, ProductoUpdateDto>();
    }
}