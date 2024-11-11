using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Shared.Dtos.DaySchedules;

namespace Application.Contracts.Commands.DaySchedules.Update;
public record UpdateDayScheduleCommand(UpdateDayScheduleDto Model) : IRequest<Result<DayScheduleDto>>;
public class UpdateDayScheduleCommandHandler : IRequestHandler<UpdateDayScheduleCommand, Result<DayScheduleDto>>
{
    private readonly IDayScheduleRepository _dayScheduleRepository;
    private readonly IMapper _mapper;

    public UpdateDayScheduleCommandHandler(IDayScheduleRepository dayScheduleRepository, IMapper mapper)
    {
        _dayScheduleRepository = dayScheduleRepository;
        _mapper = mapper;
    }
    public async Task<Result<DayScheduleDto>> Handle(UpdateDayScheduleCommand request, CancellationToken cancellationToken)
    {
        var daySchedule = await _dayScheduleRepository.GetByIdAsync(request.Model.Id);
        if (daySchedule == null)
        {
            return Result.Fail($"DaySchedule with Id: {request.Model.Id} does not exist");
        }
        
        var newStartTime = ConvertToTimeOnly(request.Model.StartTime);
        var newEndTime = ConvertToTimeOnly(request.Model.EndTime);
        
        if(newStartTime.IsFailed || newEndTime.IsFailed) 
            return Result.Fail("Invalid time format");

        daySchedule.StartTime = newStartTime.Value;
        daySchedule.EndTime = newEndTime.Value;
        
        await _dayScheduleRepository.UpdateAsync(daySchedule);
        return Result.Ok(_mapper.Map<DayScheduleDto>(daySchedule));
    }

    public Result<TimeOnly> ConvertToTimeOnly(string time)
    {
        try
        {
            var timeOnly = TimeOnly.ParseExact(time, "HH:mm");
            return Result.Ok(timeOnly);
        }
        catch (Exception)
        {
            return Result.Fail("Invalid time format");
        }
        
    }
}