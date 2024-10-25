using Domain.Entities;
using Domain.Enums;
using FluentResults;
using MediatR;
using UserDto = Application.DTOs.UserDtos.UserDto;

namespace Application.Contracts.Queries.UserQueries.GetByRole;

public record GetUsersByRoleCommand(Role Role) : IRequest<Result<IEnumerable<UserDto>>>;