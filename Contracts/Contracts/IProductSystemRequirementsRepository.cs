using Entities.Models;

using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IProductSystemRequirementsRepository
    {
        IEnumerable<ProductSystemRequirements> GetRequirements(Guid productId, bool trackChanges); //in case there are many of them
        ProductSystemRequirements GetRequirement(Guid productId, Guid id, bool trackChanges);
        void CreateRequirementsForProduct(Guid productId, ProductSystemRequirements requirements);
        void DeleteRequirements(ProductSystemRequirements systemRequirements);
    }
}
