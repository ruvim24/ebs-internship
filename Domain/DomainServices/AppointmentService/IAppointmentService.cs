using Domain.Entities;
using FluentResults;

namespace Domain.DomainServices.AppointmentService;

public interface IAppointmentService
{
    Task<Result<Appointment>> Create(int carId, int serviceId, int slotId);
}