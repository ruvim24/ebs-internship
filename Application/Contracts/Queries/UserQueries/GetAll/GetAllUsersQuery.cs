using Application.DTOs.UserDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.UserQueries.GetAll;

public record GetAllUsersCommand() : IRequest<Result<IEnumerable<UserDto>>>;