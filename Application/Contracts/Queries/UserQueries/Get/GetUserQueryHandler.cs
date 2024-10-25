using Application.DTOs.UserDtos;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.UserQueries.Get;

public class GetUserCommandHandler : IRequestHandler<GetUserQuery, Result<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<Result<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        if(request.Id <= 0){return Result.Fail("Invalid User Id");}

        var user = await _userRepository.GetByIdAsync(request.Id);
        if(user == null){return Result.Fail("User not found");}
        return Result.Ok(_mapper.Map<UserDto>(user));
    }
}