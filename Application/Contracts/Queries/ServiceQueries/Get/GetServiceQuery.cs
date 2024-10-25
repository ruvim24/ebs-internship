using Application.DTOs.Service;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.Get;

public record GetServiceQuery(int Id) : IRequest<Result<ServiceDto>>;