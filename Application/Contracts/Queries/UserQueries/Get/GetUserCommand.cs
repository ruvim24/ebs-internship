using Application.DTOs.UserDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.UserQueries.Get;

public record GetUserCommand(int Id) : IRequest<Result<UserDto>>;