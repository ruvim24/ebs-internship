using Domain.Entities.Enums;
using Domain.Entities.ServicesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public sealed class Master : BaseUser
    {

        public MasterType MasterType { get; private set; }

        private readonly IList<Service> _servicesHistory;


        private Master(int userId, string name, string surename, string adress, string email, string phoneNumber, MasterType masterType) : base(userId, name, surename, adress, email, phoneNumber)
        {
            MasterType = masterType;
            _servicesHistory = new List<Service>(); 
        }

        public static Master Create(int userId, string name, string surename, string adress, string email, string phoneNumber, MasterType masterType, IList<Service> servicesHistory)
        {
            return new Master(userId, name, surename, adress, email, phoneNumber, masterType); 
        }

        public IReadOnlyCollection<Service> GetServicesHistory()
        {
            return _servicesHistory.AsReadOnly();
        }

        public void AddService(Service service) 
        { 
            _servicesHistory.Add(service);
        }

    }
}
