using Application.DTOs.DaySchedule;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Contracts.Queries.DayScheduleQueries.GetAll;

public record GetAllDayScheduleQuery() : IRequest<Result<IEnumerable<DayScheduleDto>>>;