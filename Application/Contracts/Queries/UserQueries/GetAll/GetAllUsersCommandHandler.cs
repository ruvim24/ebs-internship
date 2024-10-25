using Application.DTOs.UserDtos;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.UserQueries.GetAll;

public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, Result<IEnumerable<UserDto>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<UserDto>>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
    {
        var allUsers = await _userRepository.GetAllAsync();
        if (allUsers == null || !allUsers.Any()) {return Result.Fail("No users found");}
        var result = _mapper.Map<IEnumerable<UserDto>>(allUsers);
        return Result.Ok(result);
    }
}