using Entities.Models;
using Contracts;
using Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Repository
{
    public class ProductSystemRequirementsRepository : RepositoryBase<ProductSystemRequirements>, IProductSystemRequirementsRepository
    {
        public ProductSystemRequirementsRepository(ProjectDbContext repositoryContext)
            : base(repositoryContext) { }

        public IEnumerable<ProductSystemRequirements> GetRequirements(Guid productId, bool trackChanges)
        {
            return FindByCondition(e => e.ProductId.Equals(productId), trackChanges);
        }

        public ProductSystemRequirements GetRequirement(Guid productId, Guid id, bool trackChanges) //if there were several requirements
        {
            return FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges).SingleOrDefault();
        }
    }
}
