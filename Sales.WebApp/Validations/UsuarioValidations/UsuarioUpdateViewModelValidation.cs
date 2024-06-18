using FluentValidation;
using Sales.WebApp.Models.Usuario;

namespace Sales.WebApp.Validations.UsuarioValidations;

public class UsuarioUpdateDtoValidation : AbstractValidator<UsuarioUpdateViewModel>
{
    public UsuarioUpdateDtoValidation()
    {
        RuleFor(x => x.Id)
            .NotNull()
                .WithMessage("El id no puede estar nulo")
            .GreaterThan(0)
                .WithMessage("El id debe ser mayor que cero");
        
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