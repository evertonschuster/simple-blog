﻿namespace SimpleBlog.Domain.Core.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> GetByIdAsync(Guid id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(Guid id);
    }
}
