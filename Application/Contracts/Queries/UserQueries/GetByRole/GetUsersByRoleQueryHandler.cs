using Application.DTOs.UserDtos;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using UserDto = Application.DTOs.UserDtos.UserDto;

namespace Application.Contracts.Queries.UserQueries.GetByRole;

public class GetUsersByRoleCommandHandler : IRequestHandler<GetUsersByRoleCommand, Result<IEnumerable<UserDto>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersByRoleCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<UserDto>>> Handle(GetUsersByRoleCommand request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetByRoleAsync(request.Role);
        if(users == null || !users.Any()) {return Result.Fail("No users found");}
        var result = _mapper.Map<IEnumerable<UserDto>>(users);
        return Result.Ok(result);
    }
}