using Domain.Entities.Users.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ServicesEntities
{
    public record ServiceParam(string serviceName,
        string description,
        ServiceType serviceType,
        decimal price,
        TimeSpan duration);
}
