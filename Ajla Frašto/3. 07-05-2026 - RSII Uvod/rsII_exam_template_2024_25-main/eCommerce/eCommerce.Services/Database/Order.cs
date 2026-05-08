using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Services.Database
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        
        [MaxLength(20)]
        public string OrderNumber { get; set; } = string.Empty;
        
        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        
        // Customer who placed the order
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        
        // Navigation property for OrderItems
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        
        // Shipping details
        [MaxLength(200)]
        public string ShippingAddress { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string ShippingCity { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string ShippingState { get; set; } = string.Empty;
        
        [MaxLength(20)]
        public string ShippingZipCode { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string ShippingCountry { get; set; } = string.Empty;
        
        // Payment information
        [MaxLength(20)]
        public string? PaymentTransactionId { get; set; }
        
        public DateTime? PaymentDate { get; set; }
        
        public string? Notes { get; set; }
    }
    
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled,
        Returned
    }
} 