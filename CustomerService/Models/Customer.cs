using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService.Models
{
    [Table("Customer", Schema = "dbo")]
    [Index(nameof(CustomerName), IsUnique = false, Name = "CustomerName_Idx")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("CustomerName")]
        [Required]
        public required string CustomerName { get; set; }

        [Column("MobileNumber")]
        public string? MobileNumber { get; set; }

        [Column("Email")]
        public string? Email { get; set; }
    }
}
