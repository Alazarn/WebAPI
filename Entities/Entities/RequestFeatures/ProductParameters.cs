using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public decimal MinPrice { get; set; } = 0m;
        public decimal MaxPrice { get; set; } = 999m;
        public bool ValidPriceRange => MaxPrice > MinPrice;

        public string SearchQuery { get; set; }

        public ProductParameters()
        {
            OrderBy = "Title";
        }
    }
}
