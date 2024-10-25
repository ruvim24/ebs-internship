using Application.DTOs.DaySchedule;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.DayScheduleCommands.Update;

public class UpdateDayScheduleCommandHandler : IRequestHandler<UpdateDayScheduleCommand, Result<DayScheduleDto>>
{
    private readonly IDayScheduleRepository _dayScheduleRepository;
    private readonly IValidator<UpdateDayScheduleCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateDayScheduleCommandHandler(IDayScheduleRepository dayScheduleRepository, IValidator<UpdateDayScheduleCommand> validator, IMapper mapper)
    {
        _dayScheduleRepository = dayScheduleRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<Result<DayScheduleDto>> Handle(UpdateDayScheduleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);        
        }
        
        var exists = await _dayScheduleRepository.GetByIdAsync(request.Model.Id);
        if (exists == null)
        {
            return Result.Fail("DaySchedule.NotFound");
        }
        var daySchedule = _mapper.Map<DaySchedule>(request);
        await _dayScheduleRepository.UpdateAsync(daySchedule);
        return Result.Ok(_mapper.Map<DayScheduleDto>(daySchedule));
    }
}