namespace net_7_angular_cars.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        void Add(T vehicle);
        Task Update(int id, T entity);
        Task Update(T entity);
        void Delete(int id);
    }
}
