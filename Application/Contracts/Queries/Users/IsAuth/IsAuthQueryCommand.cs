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
            var claims = await _userManager.GetClaimsAsync(user);

            //Include User's Id
            claims = claims.Append(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())).ToList();

            // Include role claims
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
            claims = claims.Concat(roleClaims).ToList();

            return Result.Ok<IEnumerable<Claim>>(claims);
        }

        return Result.Fail("Not authenticated");
    }
}