using Application.DTOs.User;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.User.Create;

public record CreateUserCommand(CreateUserDto model) : IRequest<Result<UserDto>>;