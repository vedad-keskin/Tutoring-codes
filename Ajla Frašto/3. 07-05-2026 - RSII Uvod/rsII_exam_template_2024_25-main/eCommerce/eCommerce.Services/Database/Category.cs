using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Services.Database
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        
        // Parent category id for hierarchical categories (optional)
        public int? ParentCategoryId { get; set; }
        
        // Navigation property for parent category
        public Category? ParentCategory { get; set; }
        
        // Navigation property for child categories
        public ICollection<Category> ChildCategories { get; set; } = new List<Category>();
        
        // Navigation property for product categories (many-to-many)
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
    }
} 