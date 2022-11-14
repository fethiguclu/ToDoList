using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using TaskProject.Application.Interfaces.Repositories;

namespace TaskProject.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        //IDbContextTransaction : EntityFrameworkCore kütüphanesine ihtiyaç vardır.
        Task<IDbContextTransaction> BeginTransactionAsync();
        public ITaskRepository _taskRepository { get; }
    }
}
