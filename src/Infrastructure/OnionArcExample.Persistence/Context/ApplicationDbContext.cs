using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskProject.Application.Interfaces.Context;
using TaskProject.Domain.Common;
using TaskProject.Domain.Entities;

namespace TaskProject.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<Tasks> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().HasQueryFilter(p => !p.IsDeleted);
        }
        public override int SaveChanges()
        {
            var entityEntries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

            foreach (var entityEntry in entityEntries)
            {
                var entity = entityEntry.Entity as BaseEntity;
                entity.ModifiedDate = DateTime.Now;
                switch (entityEntry.State)
                {
                    case EntityState.Deleted:
                        entityEntry.State = EntityState.Modified;
                        entity.IsDeleted = true;
                        break;
                    case EntityState.Added:
                        entity.uid = Guid.NewGuid();
                        entity.CreatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
