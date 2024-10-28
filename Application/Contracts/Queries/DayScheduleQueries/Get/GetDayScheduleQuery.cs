using Application.DTOs.DaySchedule;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.DayScheduleQueries.Get;

public record GetDayScheduleQuery(int Id) : IRequest<Result<DayScheduleDto>>;