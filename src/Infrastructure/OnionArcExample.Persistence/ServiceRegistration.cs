using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskProject.Application.Interfaces.Repositories;
using TaskProject.Application.Interfaces.UnitOfWork;
using TaskProject.Persistence.Context;
using TaskProject.Persistence.Repositories;
using TaskProject.Persistence.UnitOfWorks;

namespace TaskProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration?.GetConnectionString("SQLConnection")));

            serviceCollection.AddTransient<ITaskRepository, TasksRepository>();
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
