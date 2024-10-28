using Application.DTOs.AppointmentDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.AppointmentQueries.GetByCarId;

public record GetAppointmentByCarIdsQuery(int CarId) : IRequest<Result<IEnumerable<AppointmentDto>>>;