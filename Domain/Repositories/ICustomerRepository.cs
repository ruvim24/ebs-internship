using Domain.Entities.Users;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Customer GetById(Guid id);
        ICollection<Customer> GetAll();
    }
}
