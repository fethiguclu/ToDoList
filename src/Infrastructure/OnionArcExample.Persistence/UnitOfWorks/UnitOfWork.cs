using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using TaskProject.Application.Interfaces.Repositories;
using TaskProject.Application.Interfaces.UnitOfWork;
using TaskProject.Persistence.Context;
using TaskProject.Persistence.Repositories;

namespace TaskProject.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ITaskRepository _taskRepository { get; }
        public UnitOfWork(ApplicationDbContext context, ITaskRepository taskRepository)
        {
            _context = context;
            _taskRepository = taskRepository;
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
        public async ValueTask DisposeAsync() { }
    }
}
