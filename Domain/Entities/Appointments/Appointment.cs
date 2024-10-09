using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.ServicesEntities;
using Domain.Entities.Users;
using Domain.Entities.Cars;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Entities.Appointments
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime AppointmentTime { get; set; }

        public Service ServiceType { get; set; }
        public int MasterId { get; set; }
        public Master Master { get; set; }

        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
