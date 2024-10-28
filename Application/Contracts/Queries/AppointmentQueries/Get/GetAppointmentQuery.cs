using Application.DTOs.AppointmentDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.AppointmentQueries.Get;

public record GetAppointmentQuery(int Id) : IRequest<Result<AppointmentDto>>;