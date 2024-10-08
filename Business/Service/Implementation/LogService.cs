﻿using DatabaseSync.Business.Service.Interface;
using DatabaseSync.Persistence.Entities;
using DatabaseSync.Persistence.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSync.Business.Service.Implementation
{
    public class LogService : ILogService
    {
        private readonly ILocalUnitOfWork _localUnitOfWork;

        public LogService(ILocalUnitOfWork localUnitOfWork)
        {
            _localUnitOfWork = localUnitOfWork;
        }

        public async Task<List<string>> GetAllSyncLogsForViewAsync()
        {
            return await _localUnitOfWork.SyncLogs.GetQueryable()
                .OrderByDescending(x => x.SyncId)
                .Select(x => $"{x.Timestamp.ToLocalTime().ToString("yyyy-M-d h:mm:ss tt")} : {x.Message}")
                .ToListAsync();
        }

        public async Task<int> SaveLogAsync(string message)
        {
            var logEntry = CreateSyncLog(message);
            await _localUnitOfWork.SyncLogs.InsertAsync(logEntry);
            return await _localUnitOfWork.CompleteAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveLogsAsync(List<string> messages)
        {
            var syncLogs = messages.Select(CreateSyncLog).ToList();
            await _localUnitOfWork.SyncLogs.InsertRangeAsync(syncLogs);
            return await _localUnitOfWork.CompleteAsync().ConfigureAwait(false);
        }

        private SyncLog CreateSyncLog(string message)
        {
            return new SyncLog
            {
                Timestamp = DateTime.UtcNow, // Use UTC for consistency
                Message = message
            };
        }
    }
}
