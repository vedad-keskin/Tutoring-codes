using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Services.Database
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        
        // User who owns this cart
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        
        // Session ID for guest users (optional)
        [MaxLength(100)]
        public string? SessionId { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        // Navigation property for cart items
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
} 