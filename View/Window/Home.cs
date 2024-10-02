using DatabaseSync.Business.Service.Interface;

namespace DatabaseSync.View.Window
{
    public partial class Home : Form
    {
        private readonly ICustomerService _customerService;
        private readonly ILogService _logService;
        private readonly ISyncService _syncService;
        private System.Windows.Forms.Timer _syncTimer;

        public Home(ICustomerService customerService, ILogService logService, ISyncService syncService)
        {
            _customerService = customerService;
            _logService = logService;
            _syncService = syncService;
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _syncTimer = new System.Windows.Forms.Timer();
            _syncTimer.Tick += async (s, e) => await SyncCommand();
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            await RenderCustomers();
            await RenderLog();
        }

        private async void btnManualSync_Click(object sender, EventArgs e)
        {
            await SyncCommand();
        }

        private async Task SyncCommand()
        {
            this.Text = $"Database-Sync [ Synchronization Started ]";
            btnManualSync.Enabled = false;
            var result = await _syncService.SyncDataAsync();
            await RenderCustomers();
            await RenderLog();
            btnManualSync.Enabled = true;
            if (result.Status)
            {
                this.Text = $"Database-Sync [ Synchronized : {DateTime.Now}]";
            }
            else
            {
                this.Text = $"Database-Sync [ Synchronization Failed : {DateTime.Now}]";
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void inputSyncInterval_ValueChanged(object sender, EventArgs e)
        {
            int intervalMinutes = (int)inputSyncInterval.Value;

            if (intervalMinutes > 0)
            {
                lblSyncInterval.Text = $"Automatic Sync [{intervalMinutes} Min]:";
                lblSyncInterval.ForeColor = Color.DarkGreen;
                // Set the timer interval to the specified minutes (convert minutes to milliseconds)
                _syncTimer.Interval = intervalMinutes * 60 * 1000;
                _syncTimer.Start();
            }
            else
            {
                lblSyncInterval.Text = "Insert Sync Interval (in Min):";
                lblSyncInterval.ForeColor = Color.Black;
                _syncTimer.Stop();
            }
        }
    }
}
