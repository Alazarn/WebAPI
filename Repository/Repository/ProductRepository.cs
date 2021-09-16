using Entities.Models;
using Contracts;
using Entities;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.RequestFeatures;
using Repository.Extensions;

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

        public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = await FindAll(trackChanges).FilterProducts(productParameters.MinPrice, productParameters.MaxPrice)
                .Search(productParameters.SearchQuery)
                .Sort(productParameters.OrderBy)
                //.Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                //.Take(productParameters.PageSize)
                .ToListAsync();

            return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
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
