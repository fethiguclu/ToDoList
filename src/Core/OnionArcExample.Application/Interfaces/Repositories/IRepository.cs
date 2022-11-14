using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskProject.Domain.Common;

namespace TaskProject.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Remove(Guid uid);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
