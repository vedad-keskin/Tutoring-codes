using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Model.Requests
{
    public class UserUpsertRequest
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        
        [MaxLength(20)]
        [Phone]
        public string? PhoneNumber { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Only used when creating a new user
        [MinLength(6)]
        public string? Password { get; set; }
        
        // Collection of role IDs to assign to the user
        public List<int> RoleIds { get; set; } = new List<int>();
    }
} 