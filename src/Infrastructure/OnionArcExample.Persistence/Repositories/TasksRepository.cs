using TaskProject.Application.Interfaces.Repositories;
using TaskProject.Domain.Entities;
using TaskProject.Persistence.Context;

namespace TaskProject.Persistence.Repositories
{
    public class TasksRepository : Repository<Tasks>, ITaskRepository
    {
        public TasksRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
