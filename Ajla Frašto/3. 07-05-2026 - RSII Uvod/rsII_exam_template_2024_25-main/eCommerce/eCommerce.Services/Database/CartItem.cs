using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Services.Database
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int Quantity { get; set; } = 1;
        
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        // Cart that this item belongs to
        public int CartId { get; set; }
        
        [ForeignKey("CartId")]
        public Cart Cart { get; set; } = null!;
        
        // Product in the cart
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
    }
} 