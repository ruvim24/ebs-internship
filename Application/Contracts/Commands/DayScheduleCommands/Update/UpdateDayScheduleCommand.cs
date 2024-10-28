using Application.DTOs.DaySchedule;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.DayScheduleCommands.Update;

public record UpdateDayScheduleCommand(UpdateDayScheduleDto Model) : IRequest<Result<DayScheduleDto>>;