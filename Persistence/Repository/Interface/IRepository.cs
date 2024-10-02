﻿namespace DatabaseSync.Persistence.Repository.Interface
{
    /// <summary>
    /// Represents a generic repository interface for interacting with entities of type TEntity in a database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type that the repository operates on. Must be a class.</typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        // Inserts a new entity of type TEntity into the database.
        void Insert(TEntity entity);

        // Asynchronously inserts a new entity of type TEntity into the database.
        Task InsertAsync(TEntity entity);

        // Inserts a range of entities of type TEntity into the database.
        void InsertRange(IEnumerable<TEntity> entities);

        // Asynchronously inserts a range of entities of type TEntity into the database.
        Task InsertRangeAsync(IEnumerable<TEntity> entities);

        // Updates an existing entity of type TEntity in the database.
        void Update(TEntity entity);

        // Deletes an existing entity of type TEntity from the database.
        void Delete(TEntity entity);

        // Deletes a range of entities of type TEntity from the database.
        void DeleteRange(IEnumerable<TEntity> entities);

        // Returns the total number of entities of type TEntity in the database.
        int Count();

        // Asynchronously returns the total number of entities of type TEntity in the database.
        Task<int> CountAsync();

        // Returns a list of all entities of type TEntity in the database.
        List<TEntity> List();

        // Returns a list of entities of type TEntity in the database, with optional paging parameters.
        List<TEntity> List(int page, int pageSize);

        // Returns a list of all entities of type TEntity in the database asynchronously.
        Task<List<TEntity>> ListAsync();

        // Returns a list of entities of type TEntity in the database asynchronously, with optional paging parameters.
        Task<List<TEntity>> ListAsync(int page, int pageSize);

        // Returns an entity of type TEntity by its primary key from the database.
        TEntity? Find(int id);

        // Returns an entity of type TEntity by its primary key from the database asynchronously.
        Task<TEntity?> FindAsync(int id);

        // Returns an IEnumerable of entities of type TEntity from the database.
        IEnumerable<TEntity> GetEnumerable();

        // Returns an IAsyncEnumerable of entities of type TEntity from the database.
        IAsyncEnumerable<TEntity> GetAsyncEnumerable();

        // Returns an IQueryable of entities of type TEntity from the database.
        IQueryable<TEntity> GetQueryable();
    }
}
