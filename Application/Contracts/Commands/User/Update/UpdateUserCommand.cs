using Application.DTOs.User;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.User.Update;

public record UpdateUserCommand(UpdateUserDto model) : IRequest<Result>;