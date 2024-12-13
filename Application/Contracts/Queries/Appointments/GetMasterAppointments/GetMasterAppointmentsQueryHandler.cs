using Application.Contracts.Queries.Services.Get;
using Application.Contracts.Queries.Services.GetMastersService;
using Application.Contracts.Queries.Users.GetLoggedUser;
using Domain.Enums;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Appointments;

namespace Application.Contracts.Queries.Appointments.GetMasterAppointments;

public record GetMasterAppointmentsQuery() : IRequest<Result<List<MasterAppointment>>>;
public class GetMasterAppointmentsQueryHandler : IRequestHandler<GetMasterAppointmentsQuery, Result<List<MasterAppointment>>>
{
    private IMediator _mediator;
    private IMapper _mapper;
    private IAppointmentRepository _appointmentRepository;
    public GetMasterAppointmentsQueryHandler(IMediator mediator, IMapper mapper, IAppointmentRepository appointmentRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _appointmentRepository = appointmentRepository;
    }
    public async Task<Result<List<MasterAppointment>>> Handle(GetMasterAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var userResult = await _mediator.Send(new GetLoggedUserInfoCommand());
        if (userResult.IsFailed) return Result.Fail(userResult.Errors);
        var serviceResult = await _mediator.Send(new GetMasterServiceQuery(userResult.Value.Id));
        if (serviceResult.IsFailed) return Result.Fail(serviceResult.Errors);
        
        var appointments = await _appointmentRepository.GetMasterAppointments(serviceResult.Value.Id);

        var masterAppointments = appointments.Select(x => new MasterAppointment
        {
            Id = x.Id,
            CarMaker = x.Car.Maker,
            CarModel = x.Car.Model,
            StartTime = x.Slot.StartTime,
            EndTime = x.Slot.EndTime,
            Status = x.Status,
        }).ToList();

        return Result.Ok(masterAppointments);
    }
}

