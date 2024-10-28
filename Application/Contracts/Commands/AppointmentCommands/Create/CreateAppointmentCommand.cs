using System.Windows.Input;
using Application.DTOs.Appointment;
using Application.DTOs.AppointmentDtos;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.AppointmentCommands.Create;

public record CreateAppointmentCommand(CreateAppointmentDto Model) : IRequest<Result<AppointmentDto>>;