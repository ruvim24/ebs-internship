using Application.DTOs.Users;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.UserQueries.GetAll;

public record GetAllUsersQuery() : IRequest<Result<IEnumerable<UserDto>>>;

public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserDto>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await _userRepository.GetAllAsync();
        if (allUsers == null || !allUsers.Any()) {return Result.Fail("No users found");}
        var result = _mapper.Map<IEnumerable<UserDto>>(allUsers);
        return Result.Ok(result);
    }
}