using Domain.Entities;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Dtos.Users;

namespace Application.Contracts.Commands.Users;

public record AsignRoleUserCommand(AsignRoleDto AsignRoleDto) : IRequest<Result>;
public class AsignRoleUserCommandHandler : IRequestHandler<AsignRoleUserCommand, Result>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly IValidator<AsignRoleDto> _validator;

    public AsignRoleUserCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, IValidator<AsignRoleDto> validator)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _validator = validator;
    }
    public async Task<Result> Handle(AsignRoleUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.AsignRoleDto);
        if(!validationResult.IsValid) 
            return Result.Fail(string.Join(", ", validationResult.Errors.Select(item => item.ErrorMessage)));
        
        var user = await _userManager.FindByIdAsync(request.AsignRoleDto.Id.ToString());
        if(user == null) return Result.Fail("User not found");

        if (await _roleManager.RoleExistsAsync(request.AsignRoleDto.Role))
        {
            var addUserRole = await _userManager.AddToRoleAsync(user, request.AsignRoleDto.Role);
        
            if(addUserRole.Succeeded) return Result.Ok();
        }
        
        return Result.Fail("Error adding user to role");
    }
}