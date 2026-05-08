using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Services.Database
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; } = 0;
        
        // Order that this item belongs to
        public int OrderId { get; set; }
        
        [ForeignKey("OrderId")]
        public Order Order { get; set; } = null!;
        
        // Product that was ordered
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
        
        // Calculated total for this item
        [NotMapped]
        public decimal Total => Quantity * UnitPrice - Discount;
    }
} 