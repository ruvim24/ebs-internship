using Application.DTOs.Users;
using Domain.Entities;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Dtos.Users;

namespace Application.Contracts.Commands.Users.SeedAdmin
{
    public record SeedAdminCommand(AdminCreateDto Model) : IRequest<Result>;

    public class SeedAdminCommandHandler : IRequestHandler<SeedAdminCommand, Result>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IValidator<AdminCreateDto> _adminCreateValidator;

        public SeedAdminCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, IValidator<AdminCreateDto> adminCreateValidator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _adminCreateValidator = adminCreateValidator;
        }

        public async Task<Result> Handle(SeedAdminCommand request, CancellationToken cancellationToken)
        {
            var validation = _adminCreateValidator.Validate(request.Model);
            if (!validation.IsValid) return Result.Fail("Invalid model");

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
            }

            var user = await _userManager.FindByEmailAsync(request.Model.Email);
            if (user == null)
            {
                var admin = User.Create(request.Model.FullName, request.Model.Email, request.Model.PhoneNumber, request.Model.Username);
                var createAdmin = await _userManager.CreateAsync(admin.Value, request.Model.Password);

                if (createAdmin.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin.Value, "Admin");
                    return Result.Ok();
                }
                else
                {
                    return Result.Fail("Error creating user: " + string.Join(", ", createAdmin.Errors.Select(e => e.Description)));
                }
            }

            return Result.Fail("User already exists");
        }
    }
}
