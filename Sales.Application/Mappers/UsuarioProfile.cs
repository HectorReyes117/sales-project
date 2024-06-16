using AutoMapper;
using Sales.Application.Dtos.UsuarioDto;
using Sales.Domain.Entities;

namespace Sales.Application.Mappers;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioCreationDto, Usuario>();
        CreateMap<Usuario, UsuarioCreationDto>();
        CreateMap<UsuarioUpdateDto, Usuario>();
        CreateMap<Usuario, UsuarioUpdateDto>();
    }
}