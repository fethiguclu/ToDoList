using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Application.Interfaces.Repositories;
using TaskProject.Domain.Common;
using TaskProject.Persistence.Context;

namespace TaskProject.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Table { get => _context.Set<T>(); }
        public async Task<T> Add(T entity)
        {
            await Table.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public Task<T> Update(T entity)
        {
            var _entity = Table.AsNoTracking().FirstOrDefault(x => x.uid == entity.uid);
            if (_entity != null)
                entity.Id = _entity.Id;

            Table.Update(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<T> Remove(Guid uid)
        {
            var entity = Table.AsNoTracking().FirstOrDefault(x => x.uid == uid);
            Table.Remove(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return (await Table.ToListAsync()).ToList();
        }

        public async Task<T> GetById(int id)
        {
            return (await Table.ToListAsync()).FirstOrDefault(x => x.Id == id);
        }
    }
}
