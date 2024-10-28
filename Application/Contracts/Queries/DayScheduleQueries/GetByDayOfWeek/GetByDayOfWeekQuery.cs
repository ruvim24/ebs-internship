using Application.DTOs.DaySchedule;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.DayScheduleQueries.GetByDayOfWeek;

public record GetByDayOfWeekQuery(DayOfWeek DayOfWeek) : IRequest<Result<DayScheduleDto>>;