using Application.DTOs.UserDtos;
using Application.DTOs.Users;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.Users.Create;
public record CreateUserCommand(CreateUserDto Model) : IRequest<Result<UserDto>>;
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
        
        var validationResult = _validator.Validate(request.Model);

        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);
        }
            
        var user = _mapper.Map<User>(request.Model);
        var userCreate = User.Create(user.FullName, user.Email, user.PhoneNumber, user.Password, user.Role);
        await _userRepository.AddAsync(userCreate.Value);
        return Result.Ok(_mapper.Map<UserDto>(userCreate.Value));
    }
}