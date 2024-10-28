using Application.DTOs.AppointmentDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.AppointmentQueries.GetAll;

public record GetAllAppointmentsQuery() : IRequest<Result<IEnumerable<AppointmentDto>>>;