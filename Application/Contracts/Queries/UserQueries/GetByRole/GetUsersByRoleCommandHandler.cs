using Application.DTOs.UserDtos;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.UserQueries.GetByRole;

public class GetUsersByRoleCommandHandler : IRequestHandler<GetUsersByRoleCommand, Result<IEnumerable<User>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersByRoleCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<User>>> Handle(GetUsersByRoleCommand request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetByRoleAsync(request.Role);
        if(users == null || !users.Any()) {return Result.Fail("No users found");}
        var result = _mapper.Map<IEnumerable<User>>(users);
        return Result.Ok(result);
    }
}