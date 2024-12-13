using System.Security.Claims;
using Domain.Entities;
using FluentResults;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Dtos.Users;

namespace Application.Contracts.Queries.Users.GetLoggedUser;

public record GetLoggedUserInfoCommand() : IRequest<Result<UserDto>>;
public class GetLoggedUserInfoCommandHandler : IRequestHandler<GetLoggedUserInfoCommand, Result<UserDto>>
{
    IHttpContextAccessor _httpContextAccessor;
    UserManager<User> _userManager;
    IMapper _mapper;
    public GetLoggedUserInfoCommandHandler(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IMapper mapper)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<Result<UserDto>> Handle(GetLoggedUserInfoCommand request, CancellationToken cancellationToken)
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user == null || !user.Identity?.IsAuthenticated == true)
        {
            return Result.Fail("User is not logged in");
        }
        
        var userId = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        var appUser = await _userManager.FindByIdAsync(userId.ToString());

        if (appUser == null)
        {
            return Result.Fail("Utilizatorul nu a fost găsit.");
        }
   
        var userDto = _mapper.Map<UserDto>(appUser);
        return Result.Ok(userDto);
    }
}