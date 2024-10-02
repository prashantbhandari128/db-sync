﻿using Microsoft.EntityFrameworkCore.Storage;

namespace DatabaseSync.Persistence.UnitOfWork.Interface
{
    /// <summary>
    /// Defines the contract for the Unit of Work pattern.
    /// It provides access to repositories and handles database transactions.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        // Save changes
        int Complete();
        Task<int> CompleteAsync();

        // Transaction
        IDbContextTransaction BeginTransaction();
    }
}