namespace Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(Guid id);
        ICollection<T> GetAll();
        void DeleteById(Guid id);
        void Update(T entity);

    }
}