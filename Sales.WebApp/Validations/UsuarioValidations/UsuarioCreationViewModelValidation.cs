using FluentValidation;
using Sales.WebApp.Models.Usuario;

namespace Sales.WebApp.Validations.UsuarioValidations;

public class UsuarioCreationDtoValidation : AbstractValidator<UsuarioCreationViewModel>
{
    public UsuarioCreationDtoValidation()
    {
        RuleFor(v => v.Nombre)
            .NotNull()
            .WithMessage("No puede estar nulo")
            .NotEmpty()
            .WithMessage("No puede estar vacío");
        
        RuleFor(v => v.Correo)
            .NotNull()
            .WithMessage("No puede estar nulo")
            .NotEmpty()
            .WithMessage("No puede estar vacío");
        
        RuleFor(v => v.Clave)
            .NotNull()
            .WithMessage("No puede estar nulo")
            .NotEmpty()
            .WithMessage("No puede estar vacía");
        
        RuleFor(x => x.EsActivo)
            .NotNull()
            .WithMessage("No puede ser nulo");
    }
}