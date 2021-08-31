using Entities.Models;
using Contracts;
using Entities;

namespace Repository
{
    public class ProductSystemRequirementsRepository : RepositoryBase<ProductSystemRequirements>, IProductSystemRequirementsRepository
    {
        public ProductSystemRequirementsRepository(ProjectDbContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
