using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.GetByMaster;

public record GetServiceByMasterCommand(int MasterId) : IRequest<Result<IEnumerable<Service>>>;