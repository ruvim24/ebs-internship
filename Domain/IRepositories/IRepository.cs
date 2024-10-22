namespace Domain.IRepositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void DeleteById(int id);
    }
}
