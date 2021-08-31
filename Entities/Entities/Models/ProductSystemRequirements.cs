using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductSystemRequirements
    {
        [Column("RequirementId")]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string OsMin { get; set; }

        [Required]
        public string OsMax { get; set; }

        [Required]
        public string ProcessorMin { get; set; }

        [Required]
        public string ProcessorMax { get; set; }

        [Required]
        public string MemoryMin { get; set; }

        [Required]
        public string MemoryMax { get; set; }

        [Required]
        public string StorageMin { get; set; }

        [Required]
        public string StorageMax { get; set; }

        [Required]
        public string DirectXMin { get; set; }

        [Required]
        public string DirectXMax { get; set; }

        [Required]
        public string GraphicsMin { get; set; }

        [Required]
        public string GraphicsMax { get; set; }

        [Required]
        public string LanguagesSupported { get; set; }

        [Required]
        public string PrivacyPolicy { get; set; }
        
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
