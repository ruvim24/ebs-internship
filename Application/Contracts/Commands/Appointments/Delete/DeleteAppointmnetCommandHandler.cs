using Domain.IRepositories;
using FluentResults;
using MediatR;

namespace Application.Contracts.Commands.Appointments.Delete;

public record DeleteAppointmentCommand(int Id) : IRequest<Result>;
public class DeleteAppointmnetCommandHandler : IRequestHandler<DeleteAppointmentCommand, Result>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public DeleteAppointmnetCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    public async Task<Result> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        if(request.Id <= 0) return Result.Fail("Id must be greater than 0");
        
        var appointment = await _appointmentRepository.GetByIdAsync(request.Id);
        if(appointment == null) return Result.Fail($"Appointment with Id: {request.Id} not found");
        
        await _appointmentRepository.DeleteAsync(appointment);
        return Result.Ok();
    }
}