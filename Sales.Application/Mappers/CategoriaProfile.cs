using AutoMapper;
using Sales.Application.Dtos.CategoriesDto;
using Sales.Domain.Entities;

namespace Sales.Application.Mappers;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CategoriaCreationDto, Categoria>();
        CreateMap<Categoria, CategoriaCreationDto>();
        CreateMap<CategoriaUpdateDto, Categoria>();
        CreateMap<Categoria, CategoriaUpdateDto>();
    }
}