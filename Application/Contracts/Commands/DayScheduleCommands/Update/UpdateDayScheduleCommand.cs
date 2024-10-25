using Application.DTOs.DaySchedule;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.DayScheduleCommands;

public record UpdateDayScheduleCommand(UpdateDayScheduleDto Model) : IRequest<Result<DayScheduleDto>>;