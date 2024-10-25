using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.GetAll;

public record GetAllServiceCommand() : IRequest<Result<IEnumerable<Service>>>;