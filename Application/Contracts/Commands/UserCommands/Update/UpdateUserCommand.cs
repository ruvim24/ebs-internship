using Application.DTOs.UserDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.UserCommands.Update;

public record UpdateUserCommand(UpdateUserDto Model) : IRequest<Result>;