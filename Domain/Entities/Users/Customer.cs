using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Appointments;
using Domain.Entities.Cars;
using Domain.Entities.ObjectValues;

namespace Domain.Entities.Users
{
    public sealed class Customer : BaseUser
    {
        public Car Car{ get; private set; }

        private ICollection<Appointment> _appoitmentsHistory;
        public IReadOnlyCollection<Appointment> GetAppointmentsHistory => (IReadOnlyCollection<Appointment>)_appoitmentsHistory;




        private Customer(FullName fullName,Contacts contacts, Car car) : base(fullName, contacts)
        {
            Car = car;
            _appoitmentsHistory = new List<Appointment>();
        }

        /*public static Customer Create(
            FullName fullName,
            Contacts contacts,
            Car car)
        {

            //crearea Car intati si apoi acest obiect va fi argument pentur crearea Customer

            Car car = new Car(carId, customerId, carMaker, carModel, plateNumber, vin, mileage);

            return new Customer(customerId, name, surename, adress, email, phoneNumber, car);
        }*/


        public void AddAppointment(Appointment appointment) 
        { 

            //validation
            _appoitmentsHistory.Add(appointment);
        }

    }
}
