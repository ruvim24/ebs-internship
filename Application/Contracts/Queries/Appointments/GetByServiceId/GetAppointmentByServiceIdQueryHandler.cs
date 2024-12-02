using Domain.Entities;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;
using Shared.Dtos.Appointments;

namespace Application.Contracts.Queries.Appointments.GetByServiceId;

public record GetAppointmentByServiceIdQuery(int ServiceId) : IRequest<Result<AppointmentDto>>;

public class GetAppointmentByServiceIdQueryHandler : IRequestHandler<GetAppointmentByServiceIdQuery, Result<AppointmentDto>>
{
    IAppointmentRepository _repository;
    IMapper _mapper;

    public GetAppointmentByServiceIdQueryHandler(IAppointmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Result<AppointmentDto>> Handle(GetAppointmentByServiceIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetbyServiceId(request.ServiceId);

        if (result == null)
        {
            return Result.Fail("Appointment not found");
        }
        return Result.Ok(_mapper.Map<AppointmentDto>(result));
    }
}