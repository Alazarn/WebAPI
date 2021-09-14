using Entities.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductSystemRequirementsRepository
    {
        Task<IEnumerable<ProductSystemRequirements>> GetRequirementAsync(Guid productId, bool trackChanges); //in case there are many of them
        Task<ProductSystemRequirements> GetRequirementsAsync(Guid productId, Guid id, bool trackChanges);
        void CreateRequirementsForProduct(Guid productId, ProductSystemRequirements requirements);
        void DeleteRequirements(ProductSystemRequirements systemRequirements);
    }
}
