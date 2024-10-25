using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.Get;

public record GetServiceCommand(int Id) : IRequest<Result<Service>>, IRequest<Result<IEnumerable<Service>>>;