using Application.DTOs.Service;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.GetAll;

public record GetAllServiceQuery() : IRequest<Result<IEnumerable<ServiceDto>>>;