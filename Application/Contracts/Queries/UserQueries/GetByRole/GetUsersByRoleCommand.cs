using Domain.Entities;
using Domain.Enums;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.UserQueries.GetByRole;

public record GetUsersByRoleCommand(Role Role) : IRequest<Result<IEnumerable<User>>>;