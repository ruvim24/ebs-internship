using Application.DTOs.Appointment;
using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Commands.AppointmentCommands.Complete;

public class CompleteAppointmentCommandHandler : IRequestHandler<CompleteAppointmentCommand, Result<AppointmentDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public CompleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }
    public async Task<Result<AppointmentDto>> Handle(CompleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        if (request.Id < 0)
        {
            return Result.Fail("Invalid Appointment Id");
        }
        var completeAppointment = await _appointmentRepository.GetByIdAsync(request.Id);
        
        if (completeAppointment == null)
        {
            return Result.Fail("Appointment not found");
        }
        
        completeAppointment.Complete();
        await _appointmentRepository.UpdateAsync(completeAppointment);
        return Result.Ok(_mapper.Map<AppointmentDto>(completeAppointment));
    }
}