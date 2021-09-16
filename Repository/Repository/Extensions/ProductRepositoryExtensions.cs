using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Repository.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> FilterProducts(this IQueryable<Product> products, 
            decimal minPrice, decimal maxPrice)
        {
            return products.Where(p => p.Price >= minPrice &&
                p.Price <= maxPrice);
        }

        public static IQueryable<Product> Search(this IQueryable<Product> products, string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
                return products;

            var lowerCaseSearchQuery = searchQuery.Trim().ToLower();

            return products.Where(p => p.Title.ToLower().Contains(lowerCaseSearchQuery));
        }

        public static IQueryable<Product> Sort(this IQueryable<Product> products, string sortQuery)
        {
            if (string.IsNullOrWhiteSpace(sortQuery))
                return products.OrderBy(p => p.Title);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(sortQuery);
            
            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(p => p.Title);

            return products.OrderBy(orderQuery);
        }
    }
}
