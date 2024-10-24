using Application.DTOs.User;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using Mapster;
using MediatR;
using Domain.Entities;
using Domain.Enums;
using MapsterMapper;

namespace Application.Contracts.Commands.User.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserDto>>
{
    private IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private IValidator<CreateUserDto> _validator;
    
    public CreateUserCommandHandler(IUserRepository userRepository, IValidator<CreateUserDto> validator, IMapper mapper)
    {
        _userRepository = userRepository;
        _validator = validator;
        _mapper = mapper;
    }
    
    public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var vlidatorResult = _validator.Validate(request.model);
        
        if (!vlidatorResult.IsValid)
        {
            return Result.Fail("createUserDto is not valid");
        }
        var user = request.model.Adapt<User>();
        var createUser = User.Create(user.FullName, user.Email, user.Password, Role.Customer);
        await _userRepository.AddAsync(createUser);
        var result = createUser.Adapt<UserDto>();
        return result;
    }
}