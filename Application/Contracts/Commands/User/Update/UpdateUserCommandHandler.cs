using Application.DTOs.User;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Domain.Entities;

namespace Application.Contracts.Commands.User.Update;

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
        var exists = _userRepository.GetByIdAsync(request.model.Id);
        if (exists.Result == null)
        {
            return Result.Fail("User not found");
        }
        var user = _mapper.Map<User>(request);
        await _userRepository.UpdateAsync(user);
        return Result.Ok();
    }
}