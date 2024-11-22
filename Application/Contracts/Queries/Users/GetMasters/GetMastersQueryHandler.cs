using Domain.Entities;
using FluentResults;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Dtos.Users;

namespace Application.Contracts.Queries.Users.GetMasters;

public record GetMastersQuery() : IRequest<Result<IEnumerable<UserDto>>>;
public class GetMastersQueryHandler : IRequestHandler<GetMastersQuery, Result<IEnumerable<UserDto>>>
{
    IHttpContextAccessor _httpContextAccessor;
    UserManager<User> _userManager;
    IMapper _mapper;

    public GetMastersQueryHandler(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IMapper mapper)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<UserDto>>> Handle(GetMastersQuery request, CancellationToken cancellationToken)
    {
        var masters = await _userManager.GetUsersInRoleAsync("Master");

        if (masters.Any())
        {
            var masterDto = _mapper.Map<IEnumerable<UserDto>>(masters);
            return  Result.Ok(masterDto);
        }
        return Result.Fail("No master found");
    }
}