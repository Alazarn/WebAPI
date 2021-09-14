using Entities.Models;
using Contracts;
using Entities;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProjectDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(p => p.Title).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
        }

        public async Task<Product> GetProductAsync(Guid productId, bool trackChanges)
        {
            return await FindByCondition(p => p.Id.Equals(productId), trackChanges).SingleOrDefaultAsync();
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

    }
}
