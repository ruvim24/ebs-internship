using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Users;

namespace Application.Contracts.Commands.Users.Update;

public record UpdateUserCommand(UpdateUserDto Model) : IRequest<Result<UserDto>>;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UserDto>>
{
    private IUserRepository _userRepository;
    private IMapper _mapper;
    private IValidator<UpdateUserDto> _validator;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IValidator<UpdateUserDto> validator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<Result<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.Model);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(',', validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);
        }
        
        var user = await _userRepository.GetByIdAsync(request.Model.Id);
        if (user == null) return Result.Fail($"User with Id {request.Model.Id} not found");
        _mapper.Map(request.Model, user);
        await _userRepository.UpdateAsync(user);
        
        return Result.Ok(_mapper.Map<UserDto>(user));

    }
}