using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Params
{
    public class CarParam(Guid customerId, Customer customer, string maker, string model, string plateNumber, string vin, int mileage);
}
