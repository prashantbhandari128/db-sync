using System.ComponentModel.DataAnnotations;

namespace DatabaseSync.Persistence.Entities
{
    public class Customer
    {
        [Key] 
        public int CustomerID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = String.Empty;
        [Required]
        [Phone]
        [MaxLength(15)]
        public string Phone { get; set; } = String.Empty;
        public ICollection<Location>? Locations { get; set; }
    }
}
