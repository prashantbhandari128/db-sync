using DatabaseSync.Business.Service.Interface;
using System.Windows.Forms;

namespace DatabaseSync.View.Window
{
    public partial class Home : Form
    {
        private readonly ICustomerService _customerService;
        private readonly ILogService _logService;
        private readonly ISyncService _syncService;
        public Home(ICustomerService customerService, ILogService logService, ISyncService syncService)
        {
            _customerService = customerService;
            _logService = logService;
            _syncService = syncService;
            InitializeComponent();
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            await RenderCustomers();
            await RenderLog();
        }

        private async void btnManualSync_Click(object sender, EventArgs e)
        {
            btnManualSync.Enabled = false;
            await _syncService.SyncDataAsync();
            await RenderCustomers();
            await RenderLog();
            btnManualSync.Enabled = true;
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

        }
    }
}
