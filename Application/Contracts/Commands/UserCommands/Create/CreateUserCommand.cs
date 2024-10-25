using Application.DTOs.UserDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.UserCommands.Create;

public record CreateUserCommand(CreateUserDto Model) : IRequest<Result<UserDto>>;