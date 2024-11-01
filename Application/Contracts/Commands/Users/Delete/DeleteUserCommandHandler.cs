using Domain.IRepositories;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.Users.Delete;

public record DeleteUserCommand(int Id) : IRequest<Result>;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.GetByIdAsync(request.Id);
        if(result == null) return Result.Fail("User not found");
        
        await _userRepository.DeleteAsync(result);
        return Result.Ok();
    }
}