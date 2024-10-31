using Application.DTOs.UserDtos;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.Users.Update;

public record UpdateUserCommand(UpdateUserDto Model) : IRequest<Result>;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
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
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.Model);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(',', validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);
        }
        
        var exists = _userRepository.GetByIdAsync(request.Model.Id);
        if (exists.Result == null)
        {
            return Result.Fail("User.NotFound");
        }
        var user = _mapper.Map<User>(request.Model);
        await _userRepository.UpdateAsync(user);
        return Result.Ok();
    }
}