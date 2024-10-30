using Application.DTOs.ServiceDtos;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.ServiceQueries.GetByMaster;

public record GetServiceByMasterQuery(int MasterId) : IRequest<Result<IEnumerable<ServiceDto>>>;