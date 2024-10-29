using Application.DTOs.Service;
using Domain.Entities;
using Domain.Enums;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.GetByType;

public record GetServiceByTypeQuery(ServiceType Type) : IRequest<Result<IEnumerable<ServiceDto>>>;