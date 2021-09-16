using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions.Utility
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string sortQuery)
        {
            var orderParams = sortQuery.Trim().Split(',');
            var propertyInfos = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            StringBuilder stringBuilder = new();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQuery = param.Split(" ")[0];
                var objectPropety = propertyInfos.FirstOrDefault(p => p.Name.Equals(propertyFromQuery,
                    StringComparison.InvariantCulture));

                if (objectPropety == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                stringBuilder.Append($"{objectPropety.Name} {direction},");
            }

            var orderQuery = stringBuilder.ToString().TrimEnd(',', ' ');            

            return orderQuery;
        }
    }
}
