using Microsoft.EntityFrameworkCore;
using TaskProject.Domain.Entities;

namespace TaskProject.Application.Interfaces.Context
{
    public interface IApplicationContext
    {
        DbSet<Tasks> Tasks { get; set; }
    }
}
