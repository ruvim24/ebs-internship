using Domain.Entities.Users.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Cars
{
    public record CarParam(Guid customerId, Customer customer, string maker, string model, string plateNumber, string vin, int mileage);
}
