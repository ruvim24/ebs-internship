using Application.DTOs.Appointment;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.AppointmentCommands.Complete;

public record CompleteAppointmentCommand(int Id) : IRequest<Result<AppointmentDto>>;