using Entities.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTO
{
    public abstract class ProductForManipulationDto //Optional class, recommended by best practicies
    {
        [Required(ErrorMessage = "Author is a required field.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Title name is a required field.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is a required field.")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Genre is a required field.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Feature is a required field.")]
        public string Features { get; set; }

        [Required(ErrorMessage = "Platform is a required field.")]
        public string Platform { get; set; }

        public ProductSystemRequirements SystemRequirements { get; set; }
    }
}