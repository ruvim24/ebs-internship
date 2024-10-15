using Domain.Entities.Cars;
using Domain.Entities.ServicesEntities;
using Domain.Entities.Users.Customer;
using Domain.Entities.Users.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Appointments
{
    public record AppointmentParam(int id, DateTime createdAt, DateTime startTime, Service service, int masterId, Master master, int customerId, Customer customer, int carId, Car car);
}
