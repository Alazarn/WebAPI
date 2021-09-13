using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ProductForCreationDto //Optional class, recommended by best practicies
    {        
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public string Features { get; set; }
        public string Platform { get; set; }

        public ProductSystemRequirements SystemRequirements { get; set; }
    }
}
