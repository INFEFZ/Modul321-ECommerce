using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Models
{
    [Table("Product", Schema = "dbo")]
    [Index(nameof(ProductName), IsUnique = false, Name = "ProductName_Idx")]
    public class Product
    {
        [Key]
        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("ProductName")]
        [Required]
        public required string ProductName { get; set; }

        [Column("ProductCode")]
        public string? ProductCode { get; set; }

        [Column("ProductPrice", TypeName = "decimal(18,4)")]
        public decimal ProductPrice { get; set; }
    }
}
