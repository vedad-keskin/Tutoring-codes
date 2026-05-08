using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Model.Requests
{
    public class ProductInsertRequest
    {
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; } = 0;

        // SKU (Stock Keeping Unit) for inventory management
        [MaxLength(50)]
        public string? SKU { get; set; }

        // Product weight for shipping calculations (in grams)
        public decimal? Weight { get; set; }

        // Product Type relationship
        public int? ProductTypeId { get; set; }

        // Unit of Measure relationship
        public int? UnitOfMeasureId { get; set; }
        
        public AssetInsertRequest? AssetInsertRequest { get; set; }
       
        // // Navigation property for assets (images)
        // public ICollection<Asset> Assets { get; set; } = new List<Asset>();

    }
} 