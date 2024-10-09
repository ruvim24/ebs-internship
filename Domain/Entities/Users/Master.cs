using Domain.Entities.Enums;
using Domain.Entities.ObjectValues;
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

        private  ICollection<Service> _servicesHistory;
        public IReadOnlyCollection<Service> GetServicesHistory => (IReadOnlyCollection<Service>)_servicesHistory;


        private Master(FullName fullName, Contacts contacts,  MasterType masterType) : base(fullName, contacts)
        {
            MasterType = masterType;
            _servicesHistory = new List<Service>(); 
        }

        /*public static Master Create(int userId, string name, string surename, string adress, string email, string phoneNumber, MasterType masterType, IList<Service> servicesHistory)
        {
            return new Master(userId, name, surename, adress, email, phoneNumber, masterType); 
        }*/

        public void AddService(Service service) 
        { 
            _servicesHistory.Add(service);
        }

    }
}
