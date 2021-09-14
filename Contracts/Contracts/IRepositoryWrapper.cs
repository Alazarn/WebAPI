using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        IProductSystemRequirementsRepository SystemRequirements { get; }
        Task SaveAsync();
    }
}
