using Application.DTOs.Appointment;
using Application.DTOs.AppointmentDtos;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.AppointmentCommands.Complete;

public record CompleteAppointmentCommand(int Id) : IRequest<Result<AppointmentDto>>;