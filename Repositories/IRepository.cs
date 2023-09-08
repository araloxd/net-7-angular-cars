﻿namespace net_7_angular_cars.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        void Add(T vehicle);
        Task AddAsync(T vehicle);

        void Update(int id, T vehicle);
        void Delete(int id);
    }
}
