using AutoMapper;
using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.Infraestructure.Mappers;

public class UsuarioModelProfile : Profile
{
    public UsuarioModelProfile()
    {
        CreateMap<UsuarioModel, Usuario>();
        CreateMap<Usuario, UsuarioModel>();
    }
}