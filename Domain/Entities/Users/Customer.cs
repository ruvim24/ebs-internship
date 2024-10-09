using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Appointments;
using Domain.Entities.Cars;

namespace Domain.Entities.Users
{
    public sealed class Customer : BaseUser
    {
        private int Id { get;  set; }
        private Car Car{ get; set; }

        private IList<Appointment> _appoitmentsHistory { get; set; }



        private Customer(int id, string name, string surename, string adress, string email, string phoneNumber, Car car ) : base(id, name, surename, adress, email, phoneNumber)
        {
            Id = id;
            Car = car;
            _appoitmentsHistory = new List<Appointment>();
        }
        
        public static Customer Create(int customerId,
            string name,
            string surename,
            string adress,
            string email,
            string phoneNumber,

            //argumentele pentru intializarea obiectului Car
            int carId,
            string carMaker,
            string carModel,
            string plateNumber,
            string vin,
            int mileage)
        {

            //crearea Car intati si apoi acest obiect va fi argument pentur crearea Customer

            // ?? cum sa atribui campului Customer din Car referinta la acest obiect
            Car car = Car.Create(carId, customerId, carMaker, carModel, plateNumber, vin, mileage);

            return new Customer(customerId, name, surename, adress, email, phoneNumber, car);
        }

        public ICollection<Appointment> GetAppointmentsHistory()
        {
            return _appoitmentsHistory.AsReadOnly();
        }
        public void AddAppointment(Appointment appointment) 
        { 
            _appoitmentsHistory.Add(appointment);
        }

    }
}
