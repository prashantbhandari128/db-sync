namespace DatabaseSync.View.ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string Addresses { get; set; } = String.Empty;
    }
}
