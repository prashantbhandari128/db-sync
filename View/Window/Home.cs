using DatabaseSync.Business.Result;
using DatabaseSync.Business.Service.Interface;

namespace DatabaseSync.View.Window
{
    public partial class Home : Form
    {
        private readonly ICustomerService _customerService;
        private readonly ILogService _logService;
        private readonly ISynchronizationService _synchronizationService;

        public Home(ICustomerService customerService, ILogService logService, ISynchronizationService synchronizationService)
        {
            _customerService = customerService;
            _logService = logService;
            _synchronizationService = synchronizationService;
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            syncTimer.Tick += async (s, e) => await SyncCommand();
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            await RenderCustomers();
            await RenderLog();
        }

        private async void btnManualSync_Click(object sender, EventArgs e) => await SyncCommand();

        private void inputSyncInterval_ValueChanged(object sender, EventArgs e)
        {
            int intervalMinutes = (int)inputSyncInterval.Value;

            if (intervalMinutes > 0)
            {
                if (intervalMinutes > 1440) 
                {
                    MessageBox.Show("Maximum allowed time is 24 hours (1440 minutes).", "Invalid Interval", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                lblSyncInterval.Text = $"Automatic Sync [{intervalMinutes} Min]:";
                lblSyncInterval.ForeColor = Color.DarkGreen;
                // Set the timer interval to the specified minutes (convert minutes to milliseconds)
                syncTimer.Interval = intervalMinutes * 60 * 1000;
                syncTimer.Start();
            }
            else
            {
                lblSyncInterval.Text = "Insert Sync Interval (in Min):";
                lblSyncInterval.ForeColor = Color.Black;
                syncTimer.Stop();
            }
        }

        private async Task RenderCustomers()
        {
            dataGridCustomers.DataSource = await _customerService.GetAllLocalCustomersForViewAsync();
            dataGridCustomers.Refresh();
        }

        private async Task RenderLog()
        {
            lstSyncLog.DataSource = await _logService.GetAllSyncLogsForViewAsync();
            lstSyncLog.Refresh();
        }

        private async Task SyncCommand()
        {
            try
            {
                this.Text = "Database-Sync [ Synchronization Started ]";
                btnManualSync.Enabled = false;

                SynchronizationProcessResult result = await _synchronizationService.SynchronizeDatabaseAsync();

                if (result.Status)
                {
                    this.Text = result.ChangedLocally
                        ? $"Database-Sync [ Synchronized: {DateTime.Now.ToString("yyyy-M-d h:mm:ss tt")} ] | Updated"
                        : $"Database-Sync [ Synchronized: {DateTime.Now.ToString("yyyy-M-d h:mm:ss tt")} ] | Already Up to Date";
                }
                else
                {
                    this.Text = $"Database-Sync [ Synchronization Failed: {DateTime.Now.ToString("yyyy-M-d h:mm:ss tt")} ]";
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                await RenderCustomers();
                await RenderLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during synchronization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnManualSync.Enabled = true;
            }
        }
    }
}
