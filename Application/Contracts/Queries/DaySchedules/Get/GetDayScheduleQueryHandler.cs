using Application.DTOs.DaySchedules;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.DaySchedules.Get;


public record GetDayScheduleQuery(int Id) : IRequest<Result<DayScheduleDto>>;
public class GetDayScheduleQueryHandler : IRequestHandler<GetDayScheduleQuery, Result<DayScheduleDto>>
{
    private IDayScheduleRepository _dayScheduleRepository;
    private IMapper _mapper;

    public GetDayScheduleQueryHandler(IDayScheduleRepository dayScheduleRepository, IMapper mapper)
    {
        _dayScheduleRepository = dayScheduleRepository;
        _mapper = mapper;
    }

    public async Task<Result<DayScheduleDto>> Handle(GetDayScheduleQuery request, CancellationToken cancellationToken)
    {
        if(request.Id <= 0) return Result.Fail($"Id should be greater than 0");
        var daySchedule = await _dayScheduleRepository.GetByIdAsync(request.Id);
        if (daySchedule == null) return Result.Fail($"Invalid request Id");
        return Result.Ok(_mapper.Map<DayScheduleDto>(daySchedule));
    }
}