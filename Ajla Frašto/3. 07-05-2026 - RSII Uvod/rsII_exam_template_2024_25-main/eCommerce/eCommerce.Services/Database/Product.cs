using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Services.Database
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        public int StockQuantity { get; set; } = 0;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        // SKU (Stock Keeping Unit) for inventory management
        [MaxLength(50)]
        public string? SKU { get; set; }
        
        // Product weight for shipping calculations (in grams)
        public decimal? Weight { get; set; }
        
        // Product Type relationship
        public int? ProductTypeId { get; set; }
        
        [ForeignKey("ProductTypeId")]
        public ProductType? ProductType { get; set; }
        
        // Unit of Measure relationship
        public int? UnitOfMeasureId { get; set; }
        
        [ForeignKey("UnitOfMeasureId")]
        public UnitOfMeasure? UnitOfMeasure { get; set; }
        
        // Navigation property for assets (images)
        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
        
        // Navigation property for product categories (many-to-many)
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        
        // Navigation property for product reviews
        public ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();
        
        // Navigation property for order items
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        
        // Navigation property for cart items
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        [MaxLength(1000)]
        public string ProductState { get; set; } = string.Empty;
    }
} 