using Domain.Entities.ObjectValues;
using Domain.Entities.ServicesEntities;
using Domain.Entities.Users.Masters;

namespace Domain.Entities.Users
{

    public class Admin : BaseUser
    {
        private readonly ICollection<Master> _masters;
        public IReadOnlyCollection<Master> GetAllMasters => (IReadOnlyCollection<Master>)_masters;

        private readonly ICollection<Service> _services;
        public IReadOnlyCollection<Service> GetAllServices => (IReadOnlyCollection<Service>)_services;

        private Admin(FullName fullName, Contacts contacts, ICollection<Master> masters) : base(fullName, contacts)
        {
            _masters = masters;
        }
        public Admin Create(FullName fullName, Contacts contacts, ICollection<Master> masters)
        {
            return new Admin(fullName, contacts, masters);
        }

        //Add Master
        public void AddMaster(Master master)
        {   
            _masters.Add(master);
        }

        public void RemoveMaster(Master master)
        {
            _masters.Remove(master);
        }

        //Add Services
        public void AddService(Service service)
        {
            _services.Add(service);
        }

        public void RemoveService(Service service)
        {
            _services.Remove(service);
        }
        
    }
}
