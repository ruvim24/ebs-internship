using Application.DTOs.DaySchedule;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.DayScheduleQueries.GetByDayOfWeek;

public class GetDayScheduleByDayOfWeekQueryHandler : IRequestHandler<GetByDayOfWeekQuery, Result<DayScheduleDto>>
{
    private readonly IDayScheduleRepository _dayScheduleRepository;
    private readonly IMapper _mapper;

    public GetDayScheduleByDayOfWeekQueryHandler(IDayScheduleRepository repository, IMapper mapper)
    {
        _dayScheduleRepository = repository;
        _mapper = mapper;
    }
    public async Task<Result<DayScheduleDto>> Handle(GetByDayOfWeekQuery request, CancellationToken cancellationToken)
    {
        var daySchedule = await _dayScheduleRepository.GetByDayOfWeekAsync(request.DayOfWeek);
        if(daySchedule == null) return Result.Fail("Day schedule not found");
        return Result.Ok(_mapper.Map<DayScheduleDto>(daySchedule));
    }
}

