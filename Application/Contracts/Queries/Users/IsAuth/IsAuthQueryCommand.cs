using System.Security.Claims;
using Domain.Entities;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Queries.Users.IsAuth;

public record IsAuthQuery() : IRequest<Result<IEnumerable<Claim>>>;
public class IsAuthQueryCommand : IRequestHandler<IsAuthQuery, Result<IEnumerable<Claim>>>
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IsAuthQueryCommand(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<IEnumerable<Claim>>> Handle(IsAuthQuery request, CancellationToken cancellationToken)
    {
        var claimsPrincipal = _httpContextAccessor.HttpContext.User;
        if (claimsPrincipal.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            IEnumerable<Claim> claims = await _userManager.GetClaimsAsync(user);
        
            return Result.Ok(claims);  
        }
        else
        {
            return Result.Fail("not authenticated");

        }
    }
}