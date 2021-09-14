using Contracts;
using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ProjectDbContext projectContext;
        private IProductRepository productRepository;
        private IProductSystemRequirementsRepository systemRequirementsRepository;
        public RepositoryWrapper(ProjectDbContext context)
        {
            projectContext = context;
        }
        public IProductRepository Product
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(projectContext);
                return productRepository;
            }
        }
        public IProductSystemRequirementsRepository SystemRequirements
        {
            get
            {
                if (systemRequirementsRepository == null)
                    systemRequirementsRepository = new ProductSystemRequirementsRepository(projectContext);
                return systemRequirementsRepository;
            }
        }
        public Task SaveAsync() => projectContext.SaveChangesAsync();
    }
}
