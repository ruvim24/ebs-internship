using Application.DTOs.AppointmentDtos;
using Application.DTOs.Appointments;
using Domain.DomainServices.AppointmentService;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using FluentValidation;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.Appointments.Create;

public record CreateAppointmentCommand(CreateAppointmentDto Model) : IRequest<Result<AppointmentDto>>;
public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Result<AppointmentDto>>
{
    private readonly IAppointmentService _appointmentService;
    private readonly ISlotRepository _slotRepository;
    private readonly IValidator<CreateAppointmentDto> _validator;
    private readonly IMapper _mapper;

    public CreateAppointmentCommandHandler(IAppointmentService appointmentService, IValidator<CreateAppointmentDto> validator, IMapper mapper, ISlotRepository slotRepository)
    {
        _appointmentService = appointmentService;
        _validator = validator;
        _mapper = mapper;
        _slotRepository = slotRepository;
    }
    public async Task<Result<AppointmentDto>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request.Model);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            return Result.Fail(errors);
        }
        
        var appointment = _mapper.Map<Appointment>(request.Model);
        
        var createAppointment = await _appointmentService.Create(appointment.CarId, appointment.ServiceId, appointment.SlotId);
        if(createAppointment.IsFailed) return Result.Fail("Failed to create appointment");
        
        return Result.Ok(_mapper.Map<AppointmentDto>(createAppointment.Value));
    }
}