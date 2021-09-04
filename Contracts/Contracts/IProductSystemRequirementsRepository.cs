using Entities.Models;

using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IProductSystemRequirementsRepository
    {
        IEnumerable<ProductSystemRequirements> GetRequirements(Guid productId, bool trackChanges);
        ProductSystemRequirements GetRequirement(Guid productId, Guid id, bool trackChanges);
    }
}
