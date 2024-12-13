using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.DaySchedules;

namespace Application.Contracts.Queries.DaySchedules.GetAll;
public record GetAllDayScheduleQuery() : IRequest<Result<IEnumerable<DayScheduleDto>>>;
public class GetAllDayScheduleQueryHandler : IRequestHandler<GetAllDayScheduleQuery, Result<IEnumerable<DayScheduleDto>>>
{
    private IDayScheduleRepository _dayScheduleRepository;
    private IMapper _mapper;

    public GetAllDayScheduleQueryHandler(IDayScheduleRepository repository, IMapper mapper)
    {
        _dayScheduleRepository = repository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<DayScheduleDto>>> Handle(GetAllDayScheduleQuery request, CancellationToken cancellationToken)
    {
        var daySchedules = await _dayScheduleRepository.GetAllAsync();
        if(daySchedules == null || !daySchedules.Any()) return Result.Fail("No day schedules found");
        return Result.Ok(_mapper.Map<IEnumerable<DayScheduleDto>>(daySchedules));
    }
}