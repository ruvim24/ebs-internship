using Application.Contracts.Queries.Appointments.GetCustomerAppointments;
using FluentResults;
using MediatR;
using Shared.Dtos.Appointments;

namespace Application.Contracts.Queries.Appointments;

public record GetCustomersTakenSlotsDateQuery(DateTime Date) : IRequest<Result<List<SlotAppointmnentTime>>>;
public class GetCustomersTakenSlotsDateQueryHandler : IRequestHandler<GetCustomersTakenSlotsDateQuery, Result<List<SlotAppointmnentTime>>>
{
    private IMediator _mediator { get; set; }
    public GetCustomersTakenSlotsDateQueryHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<Result<List<SlotAppointmnentTime>>> Handle(GetCustomersTakenSlotsDateQuery request, CancellationToken cancellationToken)
    {
        var customerApp = await _mediator.Send(new GetCustomerAppointmentsQuery());
        
        var slotAppointmnentsDate = customerApp.Value
            .Select(x=> new SlotAppointmnentTime()
            {
                StartTime = x.StartTime, 
                 EndTime = x.EndTime
            })
            .ToList();
        return slotAppointmnentsDate;
    }
}

