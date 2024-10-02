﻿using DatabaseSync.Persistence.Context;
using DatabaseSync.Persistence.Repository.Interface.Server;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSync.Persistence.Repository.Implementation.Server
{
    public class ServerRepository<TEntity> : IServerRepository<TEntity> where TEntity : class
    {
        protected readonly ServerDbContext _context;
        private bool _disposed = false;

        public ServerRepository(ServerDbContext context)
        {
            _context = context;
        }
        public void Insert(TEntity entity) => _context.Set<TEntity>().Add(entity);

        public async Task InsertAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

        public void InsertRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().AddRange(entities);

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities) => await _context.Set<TEntity>().AddRangeAsync(entities);

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public void DeleteRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);

        public int Count() => _context.Set<TEntity>().Count();

        public async Task<int> CountAsync() => await _context.Set<TEntity>().CountAsync();

        public List<TEntity> List() => _context.Set<TEntity>().ToList();

        public List<TEntity> List(int page, int pageSize) => _context.Set<TEntity>().Skip((page - 1) * pageSize).Take(pageSize).ToList();

        public async Task<List<TEntity>> ListAsync() => await _context.Set<TEntity>().ToListAsync();

        public async Task<List<TEntity>> ListAsync(int page, int pageSize) => await _context.Set<TEntity>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        public TEntity? Find(int id) => _context.Set<TEntity>().Find(id);

        public async Task<TEntity?> FindAsync(int id) => await _context.Set<TEntity>().FindAsync(id);

        public IEnumerable<TEntity> GetEnumerable() => _context.Set<TEntity>().AsEnumerable();

        public IAsyncEnumerable<TEntity> GetAsyncEnumerable() => _context.Set<TEntity>().AsAsyncEnumerable();

        public IQueryable<TEntity> GetQueryable() => _context.Set<TEntity>().AsQueryable();
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
