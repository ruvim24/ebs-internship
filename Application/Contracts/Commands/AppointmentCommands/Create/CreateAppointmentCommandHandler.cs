using Application.DTOs.Appointment;
using Application.DTOs.AppointmentDtos;
using Domain.DomainServices.AppointmentService;
using Domain.Entities;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.AppointmentCommands.Create;

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Result<AppointmentDto>>
{
    private readonly IAppointmentService _appointmentService;
    private readonly IValidator<CreateAppointmentDto> _validator;
    private readonly IMapper _mapper;

    public CreateAppointmentCommandHandler(IAppointmentService appointmentService, IValidator<CreateAppointmentDto> validator, IMapper mapper)
    {
        _appointmentService = appointmentService;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<Result<AppointmentDto>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.Model);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);
        }
        var appointment = _mapper.Map<Appointment>(request);
        var createAppointment = await _appointmentService.Create(appointment.CarId, appointment.ServiceId, appointment.SlotId);
        return Result.Ok(_mapper.Map<AppointmentDto>(createAppointment));
    }
}