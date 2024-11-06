using Application.DTOs.Users;
using FluentValidation;

namespace Application.Validators.Users;

public class AsignRoleDtoValidator : AbstractValidator<AsignRoleDto>
{
    public AsignRoleDtoValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id cannot be null or empty");
        RuleFor(x => x.Role).NotNull().NotEmpty().WithMessage("Role cannot be null or empty");
    }
}