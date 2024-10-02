using DatabaseSync.Business.Result;
using DatabaseSync.Business.Service.Interface;
using DatabaseSync.Persistence.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSync.Business.Service.Implementation
{
    public class SyncService : ISyncService
    {
        private readonly ILocalUnitOfWork _localUnitOfWork;
        private readonly IServerUnitOfWork _serverUnitOfWork;
        private readonly ILogService _logService;

        public SyncService(ILocalUnitOfWork localUnitOfWork, IServerUnitOfWork serverUnitOfWork, ILogService logService)
        {
            _localUnitOfWork = localUnitOfWork;
            _serverUnitOfWork = serverUnitOfWork;
            _logService = logService;
        }

        public async Task<SyncProcessResult> SyncDataAsync()
        {
            using(var transaction = _localUnitOfWork.BeginTransaction())
            {
                try
                {
                    // Fetch data from the server
                    var serverCustomers = await _serverUnitOfWork.Customers.ListAsync();

                    // Sync customers
                    foreach (var serverCustomer in serverCustomers)
                    {
                        var localCustomer = await _localUnitOfWork.Customers.FindAsync(serverCustomer.CustomerID);
                        if (localCustomer == null)
                        {
                            // Insert new customer
                            await _localUnitOfWork.Customers.InsertAsync(serverCustomer);
                            if (await _localUnitOfWork.CompleteAsync() == 1)
                            {
                                await _logService.SaveLogAsync($"Inserted new customer: {serverCustomer.Name}");
                            }
                        }
                        else
                        {
                            // Update existing customer if changed
                            List<string> loglist = new List<string>();
                            bool isCustomerUpdated = false;
                            if (localCustomer.Name != serverCustomer.Name)
                            {
                                loglist.Add($"CustomerID {serverCustomer.CustomerID}: Name changed from '{localCustomer.Name}' to '{serverCustomer.Name}'");
                                localCustomer.Name = serverCustomer.Name;
                                isCustomerUpdated = true;
                            }
                            if (localCustomer.Email != serverCustomer.Email)
                            {
                                loglist.Add($"CustomerID {serverCustomer.CustomerID}: Email changed from '{localCustomer.Email}' to '{serverCustomer.Email}'");
                                localCustomer.Email = serverCustomer.Email;
                                isCustomerUpdated = true;
                            }
                            if (localCustomer.Phone != serverCustomer.Phone)
                            {
                                loglist.Add($"CustomerID {serverCustomer.CustomerID}: Phone changed from '{localCustomer.Phone}' to '{serverCustomer.Phone}'");
                                localCustomer.Phone = serverCustomer.Phone;
                                isCustomerUpdated = true;
                            }
                            if (isCustomerUpdated)
                            {
                                _localUnitOfWork.Customers.Update(localCustomer);
                                if (await _localUnitOfWork.CompleteAsync() == 1)
                                {
                                    await _logService.SaveLogsAsync(loglist);
                                }

                            }
                        }

                        // Sync locations for the customer
                        var serverCustomerLocations = await _serverUnitOfWork.Locations.GetQueryable().AsNoTracking().Where(l => l.CustomerID == serverCustomer.CustomerID).ToListAsync();
                        if (serverCustomerLocations.Count > 0)
                        {
                            foreach (var serverLocation in serverCustomerLocations)
                            {
                                var localLocation = await _localUnitOfWork.Locations.FindAsync(serverLocation.LocationID);
                                if (localLocation == null)
                                {
                                    // Insert new location
                                    await _localUnitOfWork.Locations.InsertAsync(serverLocation);
                                    if (await _localUnitOfWork.CompleteAsync() == 1)
                                    {
                                        await _logService.SaveLogAsync($"Inserted new location: {serverLocation.Address} for CustomerID: {serverCustomer.CustomerID}");
                                    }
                                }
                                else
                                {
                                    // Update existing location if changed
                                    if (localLocation.Address != serverLocation.Address)
                                    {
                                        var message = $"LocationID {serverLocation.LocationID}: Address changed from '{localLocation.Address}' to '{serverLocation.Address}' for CustomerID: {serverCustomer.CustomerID}";
                                        localLocation.Address = serverLocation.Address;
                                        _localUnitOfWork.Locations.Update(localLocation);
                                        if (await _localUnitOfWork.CompleteAsync() == 1)
                                        {
                                            await _logService.SaveLogAsync(message);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return new SyncProcessResult(true, "Synchronization Performed Successfully.");
                }
                catch (Exception ex)
                {
                    await _logService.SaveLogAsync($"Synchronization failed: {ex.Message}");
                    await transaction.RollbackAsync();
                    return new SyncProcessResult(false, ex.Message);
                }
            }
        }
    }
}
