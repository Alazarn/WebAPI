using Entities.Models;
using Contracts;
using Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProjectDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        
    }
}
