using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model.Requests
{
    public class UnitOfMeasureUpsertRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string Abbreviation { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}