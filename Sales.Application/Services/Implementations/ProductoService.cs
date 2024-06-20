using AutoMapper;
using FluentValidation;
using Sales.Application.Dtos.ProductoDto;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces;
using Sales.Domain.Models;

namespace Sales.Application.Services.Implementations;

public class ProductoService :  IProductoService
{
    private readonly IProductoRepository _productoRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductoCreationDto> _validator;
    private readonly IValidator<ProductoUpdateDto> _validatorUpdate;
    
    public ProductoService(
        IProductoRepository productoRepository, 
        IMapper mapper, 
        IValidator<ProductoCreationDto> validator, 
        IValidator<ProductoUpdateDto> validatorUpdate
        )
    {
        _productoRepository = productoRepository;
        _mapper = mapper;
        _validator = validator;
        _validatorUpdate = validatorUpdate;
    }
    
    public async Task Save(ProductoCreationDto producto)
    {
        await _validator.ValidateAndThrowAsync(producto);
        Producto product = _mapper.Map<Producto>(producto);
        await _productoRepository.Save(product); 
    }

    public async Task Update(ProductoUpdateDto producto)
    {
        await _validatorUpdate.ValidateAndThrowAsync(producto);
        Producto vent = _mapper.Map<Producto>(producto);
        vent.FechaMod = DateTime.Now;
        await _productoRepository.Update(vent);
    }

    public async Task<ProductModel?> Get(int id)
    {
        return await _productoRepository.GetProductById(id);
    }

    public async Task<List<ProductModel>> GetAll()
    {
        return await _productoRepository.GetAllProducts();
    }

    public async Task DeleteProduct(int id)
    {
        await _productoRepository.DeleteProduct(id);
    }
}