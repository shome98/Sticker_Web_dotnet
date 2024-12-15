﻿using System.Linq.Expressions;

namespace Sticker_Web_dotnet.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracked = false);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entity);
    }
}
