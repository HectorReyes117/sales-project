using AutoMapper;
using FluentValidation;
using Sales.Application.Dtos.UsuarioDto;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Domain.Models;

namespace Sales.Application.Services.Implementations;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UsuarioCreationDto> _validator;
    private readonly IValidator<UsuarioUpdateDto> _validatorUpdate;
    
    public UsuarioService(
        IUsuarioRepository usuarioRepository, 
        IMapper mapper, 
        IValidator<UsuarioCreationDto> validator, 
        IValidator<UsuarioUpdateDto> validatorUpdate
        )
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
        _validator = validator;
        _validatorUpdate = validatorUpdate;
    }
    
    public async Task Save(UsuarioCreationDto usuario)
    {
        await _validator.ValidateAndThrowAsync(usuario);
        Usuario user = _mapper.Map<Usuario>(usuario);
        await _usuarioRepository.Save(user);  
    }

    public async Task Update(UsuarioUpdateDto usuario)
    {
        await _validatorUpdate.ValidateAndThrowAsync(usuario);
        Usuario user = _mapper.Map<Usuario>(usuario);
        user.FechaMod = DateTime.Now;
        await _usuarioRepository.Update(user);
    }

    public async Task<UsuarioModel?> Get(int id)
    {
        return await _usuarioRepository.GetByUserId(id);
    }

    public async Task<List<UsuarioModel>> GetAll()
    {
        return await _usuarioRepository.GetAllUsers();
    }

    public async Task DeleteUser(int id)
    {   
        await _usuarioRepository.DeleteUser(id);
    }
}