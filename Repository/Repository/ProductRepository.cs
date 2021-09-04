using Entities.Models;
using Contracts;
using Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProjectDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(p => p.Title).ToList();
        }

        public Product GetProduct(Guid productId, bool trackChanges)
        {
            return FindByCondition(p => p.Id.Equals(productId), trackChanges).SingleOrDefault();
        }
    }
}
