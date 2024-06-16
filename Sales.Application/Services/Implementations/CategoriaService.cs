using AutoMapper;
using FluentValidation;
using Sales.Application.Dtos.CategoriesDto;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;

namespace Sales.Application.Services.Implementations;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CategoriaCreationDto> _validator;
    private readonly IValidator<CategoriaUpdateDto> _validatorUpdate;

    public CategoriaService(
        ICategoriaRepository categoriaRepository, 
        IMapper mapper, 
        IValidator<CategoriaCreationDto> validator, 
        IValidator<CategoriaUpdateDto> validatorUpdate)
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
        _validator = validator;
        _validatorUpdate = validatorUpdate;
    }

    public async Task Save(CategoriaCreationDto category)
    {
        await _validator.ValidateAndThrowAsync(category);
        Categoria cate = _mapper.Map<Categoria>(category);
        await _categoriaRepository.Save(cate);    
    }

    public async Task Update(CategoriaUpdateDto category)
    {
        await _validatorUpdate.ValidateAndThrowAsync(category);
        Categoria cate = _mapper.Map<Categoria>(category);
        cate.FechaMod = DateTime.Now;
        await _categoriaRepository.Update(cate);
    }
    
    public async Task<Categoria?> Get(int id)
    {
        return await _categoriaRepository.Get(id);
    }

    public async Task<List<Categoria>> GetAll()
    {
        return await _categoriaRepository.GetAll(null!);
    }
}