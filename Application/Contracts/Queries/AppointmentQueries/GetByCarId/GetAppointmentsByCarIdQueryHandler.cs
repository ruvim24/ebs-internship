using Application.DTOs.AppointmentDtos;
using Domain.IRepositories;
using FluentResults;
using MapsterMapper;
using MediatR;

namespace Application.Contracts.Queries.AppointmentQueries.GetByCarId;

public class GetAppointmentsByCarIdQueryHandler : IRequestHandler<GetAppointmentByCarIdsQuery, Result<IEnumerable<AppointmentDto>>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public GetAppointmentsByCarIdQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }
    public async Task<Result<IEnumerable<AppointmentDto>>> Handle(GetAppointmentByCarIdsQuery request, CancellationToken cancellationToken)
    {
        var result = await _appointmentRepository.GetByCarIdAsync(request.CarId);
        if(result == null) return Result.Fail("Not Appointments Found");
        return Result.Ok(_mapper.Map<IEnumerable<AppointmentDto>>(result));
    }
}