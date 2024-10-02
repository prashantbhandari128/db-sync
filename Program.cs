using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DatabaseSync.Persistence.Context;
using DatabaseSync.View.Window;
using DatabaseSync.Persistence.Repository.Implementation.Local;
using DatabaseSync.Persistence.Repository.Implementation.Server;
using DatabaseSync.Persistence.Repository.Interface.Server;
using DatabaseSync.Persistence.Repository.Interface.Local;
using DatabaseSync.Business.Service.Implementation;
using DatabaseSync.Business.Service.Interface;
using DatabaseSync.Persistence.UnitOfWork.Interface;
using DatabaseSync.Persistence.UnitOfWork.Implementation;

namespace DatabaseSync
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
            {
                var host = CreateHostBuilder().Build();
                serviceProvider = host.Services;
                Application.Run(serviceProvider.GetRequiredService<Home>());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public static IServiceProvider? serviceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    AddForms(services);
                    AddDatabaseContext(services);
                    AddRepositories(services);
                    AddUnitOfWorks(services);
                    AddServices(services);
                });
        }

        //-------------------------------[ Inject Forms ]---------------------------------------
        static void AddForms(IServiceCollection services)
        {
            services.AddTransient<Home>();
        }
        //--------------------------------------------------------------------------------------

        //-----------------------------[ Inject DbContexts ]------------------------------------
        static void AddDatabaseContext(IServiceCollection services)
        {
            services.AddDbContext<LocalDbContext>();
            services.AddDbContext<ServerDbContext>();
        }
        //--------------------------------------------------------------------------------------

        //-------------------------[ Inject Repositories Here ]---------------------------------
        static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(ILocalRepository<>), typeof(LocalRepository<>));
            services.AddTransient<ILocalCustomerRepository, LocalCustomerRepository>();
            services.AddTransient<ILocalLocationRepository, LocalLocationRepository>();
            services.AddTransient<ILocalSyncLogRepository, LocalSyncLogRepository>();
            services.AddTransient(typeof(IServerRepository<>), typeof(ServerRepository<>));
            services.AddTransient<IServerCustomerRepository, ServerCustomerRepository>();
            services.AddTransient<IServerLocationRepository, ServerLocationRepository>();
        }
        //--------------------------------------------------------------------------------------

        //--------------------------[ Inject UnitOfWorks Here ]---------------------------------
        static void AddUnitOfWorks(IServiceCollection services)
        {
            services.AddTransient<ILocalUnitOfWork, LocalUnitOfWork>();
            services.AddTransient<IServerUnitOfWork, ServerUnitOfWork>();
        }
        //--------------------------------------------------------------------------------------

        //----------------------------[ Inject Services Here ]----------------------------------
        static void AddServices(IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<ISyncService, SyncService>();
        }
        //--------------------------------------------------------------------------------------
    }
}