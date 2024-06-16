using FluentValidation;
using Sales.Application.Dtos.UsuarioDto;
using Sales.Domain.Interfaces;

namespace Sales.Application.Validations.UsuarioValidations;

public class UsuarioUpdateDtoValidation : AbstractValidator<UsuarioUpdateDto>
{
    public UsuarioUpdateDtoValidation(
        IUsuarioRepository usuarioRepository
        )
    {
        RuleFor(x => x.Id)
            .NotNull()
                .WithMessage("El id no puede estar nulo")
            .GreaterThan(0)
                .WithMessage("El id debe ser mayor que cero")
            .MustAsync(async (id, _) =>
            {
                return !(await usuarioRepository.Exist(x => x.Id == id));
            }).WithMessage("El usuario no existe");
        
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