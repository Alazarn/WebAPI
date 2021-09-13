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

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(p => p.Title).ToList();
        }

        public IEnumerable<Product> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            return FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();
        }

        public Product GetProduct(Guid productId, bool trackChanges)
        {
            return FindByCondition(p => p.Id.Equals(productId), trackChanges).SingleOrDefault();
        }
    }
}
