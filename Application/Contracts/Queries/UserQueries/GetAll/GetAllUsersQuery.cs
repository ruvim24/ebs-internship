using Application.DTOs.UserDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.UserQueries.GetAll;

public record GetAllUsersQuery() : IRequest<Result<IEnumerable<UserDto>>>;