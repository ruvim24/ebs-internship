using System.Windows.Input;
using Application.DTOs.Appointment;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.AppointmentCommands.Cancel;

public record CancelAppointmentCommand(int Id) : IRequest<Result<AppointmentDto>>;