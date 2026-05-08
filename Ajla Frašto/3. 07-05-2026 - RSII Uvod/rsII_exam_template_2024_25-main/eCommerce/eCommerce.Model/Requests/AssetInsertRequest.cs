using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Model.Requests
{
    public class AssetInsertRequest
    {
        [Required]
        [MaxLength(100)]
        public string FileName { get; set; } = string.Empty;
        
        [Required]
        public string ContentType { get; set; } = string.Empty;
        
        [Required]
        public string Base64Content { get; set; } = string.Empty;

    }
}