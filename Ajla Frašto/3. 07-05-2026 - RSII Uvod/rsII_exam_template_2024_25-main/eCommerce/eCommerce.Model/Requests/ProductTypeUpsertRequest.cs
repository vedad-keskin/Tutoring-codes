using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model.Requests
{
    public class ProductTypeUpsertRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
    }
} 