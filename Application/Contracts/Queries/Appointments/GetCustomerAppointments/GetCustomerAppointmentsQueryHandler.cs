using Application.Contracts.Queries.Cars.Get;
using Application.Contracts.Queries.Cars.GetByCustomerId;
using Application.Contracts.Queries.Users.GetLoggedUser;
using Domain.Enums;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Shared.Dtos.Appointments;
using Shared.Dtos.Users;

namespace Application.Contracts.Queries.Appointments.GetCustomerAppointments;

public record GetCustomerAppointmentsQuery() : IRequest<Result<List<CustumerAppointmentDto>>>; 
public class GetCustomerAppointmentsQueryHandler : IRequestHandler<GetCustomerAppointmentsQuery, Result<List<CustumerAppointmentDto>>>
{
    private IMediator _mediator;
    private IMapper _mapper;
    private IAppointmentRepository _appointmentRepository;
    

    public GetCustomerAppointmentsQueryHandler(IMediator mediator, IMapper mapper, IAppointmentRepository appointmentRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _appointmentRepository = appointmentRepository;
    }
    public async Task<Result<List<CustumerAppointmentDto>>> Handle(GetCustomerAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var userResult = await _mediator.Send(new GetLoggedUserInfoCommand());
        if (userResult.IsFailed) return Result.Fail<List<CustumerAppointmentDto>>(userResult.Errors);

        var carResult = await _mediator.Send(new GetCarByCustomerIdQuery(userResult.Value.Id));
        if (carResult.IsFailed) return Result.Fail<List<CustumerAppointmentDto>>(carResult.Errors);

        var appointments = await _appointmentRepository.GetCustomerAppointments(carResult.Value.Id);

        var customerAppointments = appointments.Select(x => new CustumerAppointmentDto
        {
            Id = x.Id,
            Name = x.Service.Name,
            Price = x.Service.Price,
            StartTime = x.Slot.StartTime,
            EndTime = x.Slot.EndTime,
            Status = x.Status,
            CreatedAt = x.CreatedAt
        }).ToList();

        return Result.Ok(customerAppointments);
    }

}


