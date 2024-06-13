using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Sales.Application.Dtos.CategoriesDto;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services.Implementations;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CategoriaCreationDto> _validator;

    public CategoriaService(
        ICategoriaRepository categoriaRepository, 
        IMapper mapper, 
        IValidator<CategoriaCreationDto> validator
        )
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Save(CategoriaCreationDto category)
    {
        await _validator.ValidateAndThrowAsync(category);
        Categoria cate = _mapper.Map<Categoria>(category);
        await _categoriaRepository.Save(cate);    
    }

    public Task Save(List<CategoriaCreationDto> categories)
    {
        throw new NotImplementedException();
    }

    public Task Update(CategoriaUpdateDto category)
    {
        throw new NotImplementedException();
    }

    public Task Update(List<CategoriaUpdateDto> categories)
    {
        throw new NotImplementedException();
    }

    public Task<Categoria?> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Categoria>> GetAll()
    {
        throw new NotImplementedException();
    }
}