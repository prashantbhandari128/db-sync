using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSync.Persistence.Entities
{
    public class Location
    {
        [Key] 
        public int LocationID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }
    }
}
