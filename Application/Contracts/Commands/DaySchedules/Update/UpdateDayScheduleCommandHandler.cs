using Application.DTOs.DaySchedules;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.DaySchedules.Update;
public record UpdateDayScheduleCommand(UpdateDayScheduleDto Model) : IRequest<Result<DayScheduleDto>>;
public class UpdateDayScheduleCommandHandler : IRequestHandler<UpdateDayScheduleCommand, Result<DayScheduleDto>>
{
    private readonly IDayScheduleRepository _dayScheduleRepository;
    private readonly IValidator<UpdateDayScheduleDto> _validator;
    private readonly IMapper _mapper;

    public UpdateDayScheduleCommandHandler(IDayScheduleRepository dayScheduleRepository, IValidator<UpdateDayScheduleDto> validator, IMapper mapper)
    {
        _dayScheduleRepository = dayScheduleRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<Result<DayScheduleDto>> Handle(UpdateDayScheduleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.Model);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);        
        }
        
        var daySchedule = await _dayScheduleRepository.GetByIdAsync(request.Model.Id);
        if (daySchedule == null)
        {
            return Result.Fail($"DaySchedule with Id: {request.Model.Id} does not exist");
        }
        
        _mapper.Map(request.Model, daySchedule);
        await _dayScheduleRepository.UpdateAsync(daySchedule);
        return Result.Ok(_mapper.Map<DayScheduleDto>(daySchedule));
    }
}