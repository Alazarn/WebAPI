using Entities.Models;
using Contracts;
using Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductSystemRequirementsRepository : RepositoryBase<ProductSystemRequirements>, IProductSystemRequirementsRepository
    {
        public ProductSystemRequirementsRepository(ProjectDbContext repositoryContext)
            : base(repositoryContext) { }

        public async Task<IEnumerable<ProductSystemRequirements>> GetRequirementAsync(Guid productId, bool trackChanges)
        {
            return await FindByCondition(e => e.ProductId.Equals(productId), trackChanges).ToListAsync();
        }

        public async Task<ProductSystemRequirements> GetRequirementsAsync(Guid productId, Guid id, bool trackChanges) //if there were several requirements
        {
            return await FindByCondition(p => p.ProductId.Equals(productId) && p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateRequirementsForProduct(Guid productId, ProductSystemRequirements requirements)
        {
            requirements.ProductId = productId;
            Create(requirements);
        }

        public void DeleteRequirements(ProductSystemRequirements systemRequirements)
        {
            Delete(systemRequirements);
        }
    }
}
