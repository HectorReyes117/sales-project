using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Dtos.CategoriesDto;
using Sales.Application.Validations.CategoriaValidations;

namespace Sales.IOC.Dependencies.Validations;

public static class CategoriaValidationDependency
{
    public static void RegisterCategoriaValidations(this IServiceCollection services)
    { 
        services.AddValidatorsFromAssemblyContaining<CategoriaCreationDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<CategoriaUpdateDtoValidator>();
    }
}