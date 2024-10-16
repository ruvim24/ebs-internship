using Domain.Entities.Cars;
using Domain.Entities.ServicesEntities;
using Domain.Entities.Users.Customer;
using Domain.Entities.Users.Masters;

namespace Domain.Entities.Appointments
{
    public record AppointmentParam(DateTime createdAt, 
        DateTime startTime, 
        Service service, 
        int masterId, 
        Master master, 
        int customerId, 
        Customer customer, 
        Guid carId, 
        Car car);
}
